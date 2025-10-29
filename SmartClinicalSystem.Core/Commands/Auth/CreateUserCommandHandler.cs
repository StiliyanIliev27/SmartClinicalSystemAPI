using BuildingBlock.BuildingBlocks.CQRS;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SmartClinicalSystem.Core.Exceptions;
using SmartClinicalSystem.Infrastructure.Data.Models;
namespace SmartClinicalSystem.Core.Commands.Auth
{
    public record CreateUserCommand(string Username, string Email, string Password)
        : ICommand<CreateUserResult>;
    public record CreateUserResult(string UserId);

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public const int MINIMUM_USERNAME_LENGTH = 3;
        public const int MAXIMUM_USERNAME_LENGTH = 50;
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Username)
                .MinimumLength(MINIMUM_USERNAME_LENGTH)
                .MaximumLength(MAXIMUM_USERNAME_LENGTH)
                .NotEmpty().WithMessage("Username is required.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
    public class CreateUserCommandHandler(UserManager<ApplicationUser> userManager)
        : ICommandHandler<CreateUserCommand, CreateUserResult>
    {
        public async Task<CreateUserResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await userManager.FindByEmailAsync(request.Email) != null)
            {
                throw new UserAlreadyExistsException("email");
            }
            else if (await userManager.FindByNameAsync(request.Username) != null)
            {
                throw new UserAlreadyExistsException("username");
            }

            var user = new ApplicationUser
            {
                UserName = request.Username,
                Email = request.Email,
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new UserCreationFailedException(errors);
            }

            await userManager.AddToRoleAsync(user, "User");

            return new CreateUserResult(user.Id);
        }
    }
}
