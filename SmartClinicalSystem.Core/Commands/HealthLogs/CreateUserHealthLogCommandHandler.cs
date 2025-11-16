using BuildingBlock.BuildingBlocks.CQRS;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.DTOs.UserHealthLog;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Commands.HealthLogs
{
    public record CreateUserHealthCommand(CreateUserHealthLogDto CreateUserHealthLogDto) : ICommand<CreateUserHealthLogResult>;
    public record CreateUserHealthLogResult(string Id);
    public class CreateUserHealthLogCommandHandler(IRepository repository)
        : ICommandHandler<CreateUserHealthCommand, CreateUserHealthLogResult>
    {
        public async Task<CreateUserHealthLogResult> Handle(CreateUserHealthCommand command, CancellationToken cancellationToken)
        {
            var userHealthLog = new UserHealthLog
            {
                UserId = command.CreateUserHealthLogDto.UserId,
                SideEffects = command.CreateUserHealthLogDto.SideEffects,
                Symptoms = command.CreateUserHealthLogDto.Symptoms,
                Mood = command.CreateUserHealthLogDto.Mood,
                Notes = command.CreateUserHealthLogDto.Notes,
                PainLevel = command.CreateUserHealthLogDto.PainLevel,
                Temperature = command.CreateUserHealthLogDto.Temperature,
            };

            await repository.AddAsync(userHealthLog);
            await repository.SaveChangesAsync();

            return new CreateUserHealthLogResult(userHealthLog.Id);
        }
    }
}
