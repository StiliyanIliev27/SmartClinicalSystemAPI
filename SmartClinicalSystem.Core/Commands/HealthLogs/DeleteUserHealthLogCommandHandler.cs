using BuildingBlock.BuildingBlocks.CQRS;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.Exceptions.NotFound;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Commands.HealthLogs
{
    public record DeleteUserHealthLogCommand(string Id) : ICommand<DeleteUserHealthLogResult>;
    public record class DeleteUserHealthLogResult(bool Success, string Message);
    public class DeleteUserHealthLogCommandHandler(IRepository repository)
        : ICommandHandler<DeleteUserHealthLogCommand, DeleteUserHealthLogResult>
    {
        public async Task<DeleteUserHealthLogResult> Handle(DeleteUserHealthLogCommand command, CancellationToken cancellationToken)
        {
            var userHealthLog = await repository.GetByIdAsync<UserHealthLog>(command.Id);

            if(userHealthLog == null)
            {
                throw new UserHealthLogNotFoundException(command.Id);
            }

            repository.Delete(userHealthLog);
            await repository.SaveChangesAsync();

            return new DeleteUserHealthLogResult(true, $"User health log ({command.Id}) deleted successfully.");
        }
    }
}
