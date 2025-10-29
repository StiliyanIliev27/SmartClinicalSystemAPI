using BuildingBlock.BuildingBlocks.CQRS;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.Exceptions;
using SmartClinicalSystem.Infrastructure.Common;
using SmartClinicalSystem.Infrastructure.Data.Models;
using static SmartClinicalSystem.Core.DTOs.Auth.AuthDTOs;

namespace SmartClinicalSystem.Core.Commands.Auth
{
    public record AuthenticateUserCommand(string Username, string Password)
        : ICommand<AuthenticateUserResult>;
    public record AuthenticateUserResult(
        string AccessToken,
        string RefreshToken,
        string TokenType,
        int ExpiresIn,
        AuthenticatedUserDto User
    );

    public class AuthenticateUserCommandValidator
        : AbstractValidator<AuthenticateUserCommand>
    {
        public AuthenticateUserCommandValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
    public class AuthenticateUserCommandHandler(
        UserManager<ApplicationUser> userManager,
        IJwtService jwtService,
        IRepository repository)
        : ICommandHandler<AuthenticateUserCommand, AuthenticateUserResult>
    {
        public async Task<AuthenticateUserResult> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.Username);

            if (user == null || !await userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new InvalidUserCredentialsException();
            }

            IList<string> roles = await userManager.GetRolesAsync(user);

            var accessToken = jwtService.GenerateAccessToken(user, roles);
            var refreshToken = jwtService.GenerateRefreshToken(user);

            // Save refresh token in DB
            await repository.AddAsync(refreshToken);
            await repository.SaveChangesAsync();

            return new AuthenticateUserResult(
                accessToken,
                refreshToken.Token,
                "Bearer",
                3600,
                new AuthenticatedUserDto(user.Id, user.UserName!, user.Email!, roles)
            );
        }
    }
}
