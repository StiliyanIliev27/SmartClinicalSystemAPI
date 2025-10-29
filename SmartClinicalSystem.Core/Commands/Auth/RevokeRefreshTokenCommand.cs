using BuildingBlock.BuildingBlocks.CQRS;
using BuildingBlock.BuildingBlocks.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Commands.Auth
{
    public record RevokeRefreshTokenCommand(string RefreshToken) : ICommand<Unit>;

    public class RevokeRefreshTokenCommandValidator : AbstractValidator<RevokeRefreshTokenCommand>
    {
        public RevokeRefreshTokenCommandValidator()
        {
            RuleFor(x => x.RefreshToken)
                .NotEmpty().WithMessage("Refresh token is required.");
        }
    }

    // Handler
    public class RevokeRefreshTokenCommandHandler(IRepository repository)
        : ICommandHandler<RevokeRefreshTokenCommand, Unit>
    {
        public async Task<Unit> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var token = await repository.All<RefreshToken>()
                .FirstOrDefaultAsync(rt => rt.Token == request.RefreshToken, cancellationToken);

            if (token is null)
                throw new NotFoundException($"Refresh token '{request.RefreshToken}' not found.");

            if (!token.IsActive)
                throw new InvalidOperationException("Refresh token is already expired or revoked.");

            token.Revoked = true;

            // (optional) cleanup old tokens for this user
            var expiredTokens = (await repository.All<RefreshToken>()
                .Where(rt => rt.UserId == token.UserId)
                .ToListAsync(cancellationToken))
                .Where(rt => rt.IsExpired)
                .ToList();


            if (expiredTokens.Count > 0)
                repository.RemoveRange(expiredTokens);

            await repository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
