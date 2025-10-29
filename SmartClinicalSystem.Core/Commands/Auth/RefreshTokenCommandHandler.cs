using SmartClinicalSystem.Infrastructure.Data.Models;
using BuildingBlock.BuildingBlocks.CQRS;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SmartClinicalSystem.Core.Contracts;
using static SmartClinicalSystem.Core.DTOs.Auth.AuthDTOs;
using System.Security.Claims;
using SmartClinicalSystem.Infrastructure.Data;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;

namespace SmartClinicalSystem.Core.Commands.Auth
{
    public record RefreshTokenCommand(string AccessToken, string RefreshToken)
        : ICommand<AuthenticateUserResult>;

    public class RefreshTokenCommandHandler(
        SmartClinicalSystemDbContext context,
        IJwtService jwtService,
        UserManager<ApplicationUser> userManager)
        : ICommandHandler<RefreshTokenCommand, AuthenticateUserResult>
    {
        public async Task<AuthenticateUserResult> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var principal = jwtService.GetPrincipalFromExpiredToken(request.AccessToken)
                ?? throw new SecurityTokenException("Invalid access token");

            var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? principal.FindFirstValue(JwtRegisteredClaimNames.Sub)
                ?? throw new SecurityTokenException("Invalid token claims");

            var user = await userManager.FindByIdAsync(userId)
                ?? throw new SecurityTokenException("User not found");

            var storedToken = await context.RefreshTokens
                .FirstOrDefaultAsync(x => x.Token == request.RefreshToken && x.UserId == user.Id, cancellationToken);

            if (storedToken is null || !storedToken.IsActive)
                throw new SecurityTokenException("Invalid or expired refresh token");

            // Invalidate old token
            storedToken.Revoked = true;
            context.RefreshTokens.Update(storedToken);

            // Generate new tokens
            var roles = await userManager.GetRolesAsync(user);
            var newAccessToken = jwtService.GenerateAccessToken(user, roles);
            var newRefreshToken = jwtService.GenerateRefreshToken(user);

            await context.RefreshTokens.AddAsync(newRefreshToken, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return new AuthenticateUserResult(
                newAccessToken,
                newRefreshToken.Token,
                "Bearer",
                900, // 15 min
                new AuthenticatedUserDto(user.Id, user.UserName!, user.Email!, roles)
            );
        }
    }
}
