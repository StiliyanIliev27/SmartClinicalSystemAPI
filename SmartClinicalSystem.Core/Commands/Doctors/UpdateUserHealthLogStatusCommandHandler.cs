using BuildingBlock.BuildingBlocks.CQRS;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.Exceptions.NotFound;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Commands.Doctors
{
    public record UpdateUserHealthLogStatusCommand(string UserHealthLogToDoctorId) : ICommand<UpdateUserHealthLogStatusResult>;
    public record UpdateUserHealthLogStatusResult(bool IsSucceded, string Message);
    public class UpdateUserHealthLogStatusCommandHandler(IRepository repository) : ICommandHandler<UpdateUserHealthLogStatusCommand, UpdateUserHealthLogStatusResult>
    {
        public async Task<UpdateUserHealthLogStatusResult> Handle(UpdateUserHealthLogStatusCommand command, CancellationToken cancellationToken)
        {
            var userHealthLogToDoctor = await repository.GetByIdAsync<UserHealthLogToDoctor>(command.UserHealthLogToDoctorId);

            if (userHealthLogToDoctor == null)
            {
                throw new UserHealthLogToDoctorNotFoundException(command.UserHealthLogToDoctorId);
            }

            userHealthLogToDoctor.IsViewedByDoctor = true;
            await repository.SaveChangesAsync();

            return new UpdateUserHealthLogStatusResult(true, "Successfully updated Is view by doctor status to true");
        }
    }
}
