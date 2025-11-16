using BuildingBlock.BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.DTOs.UserHealthLog;
using SmartClinicalSystem.Core.Exceptions.NotFound;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Commands.HealthLogs
{
    public record UpdateUserHealthLogCommand(UpdateUserHealthLogDto UpdateUserHealthLogDto) : ICommand<UpdateUserHealthLogResult>;
    public record UpdateUserHealthLogResult(UserHealthLog Result);
    public class UpdateUserHealthLogCommandHandler(IRepository repository) : ICommandHandler<UpdateUserHealthLogCommand, UpdateUserHealthLogResult>
    {
        public async Task<UpdateUserHealthLogResult> Handle(UpdateUserHealthLogCommand command, CancellationToken cancellationToken)
        {
            var userHealthLog = await repository.GetByIdAsync<UserHealthLog>(command.UpdateUserHealthLogDto.Id);

            if (userHealthLog == null)
            {
                throw new UserHealthLogNotFoundException(command.UpdateUserHealthLogDto.Id);
            }

            userHealthLog.SideEffects = command.UpdateUserHealthLogDto.SideEffects;
            userHealthLog.PainLevel = command.UpdateUserHealthLogDto.PainLevel;
            userHealthLog.Symptoms = command.UpdateUserHealthLogDto.Symptoms;
            userHealthLog.Notes = command.UpdateUserHealthLogDto.Notes;
            userHealthLog.Temperature = command.UpdateUserHealthLogDto.Temperature;
            userHealthLog.Mood = command.UpdateUserHealthLogDto.Mood;
            userHealthLog.UpdatedAt = DateTime.Now;

            await repository.SaveChangesAsync();

            return new UpdateUserHealthLogResult(userHealthLog);
        }
    }
}
