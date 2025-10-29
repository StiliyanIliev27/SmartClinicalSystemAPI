using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartClinicalSystem.Core.Commands.Auth;
using static SmartClinicalSystem.API.Contracts.Requests.AuthRequests;

namespace SmartClinicalSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> SignIn([FromBody]SignInRequest request)
        {
            var command = mapper.Map<AuthenticateUserCommand>(request);
            var result = await mediator.Send(command);

            // Set refresh token cookie
            Response.Cookies.Append(
                "refreshToken",
                result.RefreshToken,
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddDays(7)
                });

            return Ok(new
            {
                accessToken = result.AccessToken,
                tokenType = result.TokenType,
                expiresIn = result.ExpiresIn,
                user = result.User
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> SignUp([FromBody]SignUpRequest request)
        {
            var command = mapper.Map<CreateUserCommand>(request);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if (!string.IsNullOrEmpty(refreshToken))
            {
                await mediator.Send(new RevokeRefreshTokenCommand(refreshToken)); 
                Response.Cookies.Delete("refreshToken");
            }

            return Ok(new { message = "Logged out successfully" });
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refreshToken))
                return Unauthorized();

            var accessToken = Request.Headers.Authorization.ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized();

            var result = await mediator.Send(new RefreshTokenCommand(accessToken, refreshToken));

            Response.Cookies.Append(
                "refreshToken",
                result.RefreshToken,
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddDays(7)
                });

            return Ok(new
            {
                accessToken = result.AccessToken,
                tokenType = "Bearer",
                expiresIn = result.ExpiresIn,
                user = result.User
            });
        }


    }
}
