using BuildingBlock.BuildingBlocks.CQRS;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.Exceptions.NotFound;
using SmartClinicalSystem.Infrastructure.Data.Enums;
using SmartClinicalSystem.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClinicalSystem.Core.Commands.Users
{
    public record SendHealthLogToDoctorCommand(string UserHealthLogId, string DoctorId) : ICommand<SendHealthLogToDoctorResult>;
    public record SendHealthLogToDoctorResult(bool IsSucceded, string Message);
    public class SendHealthLogToDoctorCommandHandler(IRepository repository, INotificationService notificationService) : ICommandHandler<SendHealthLogToDoctorCommand, SendHealthLogToDoctorResult>
    {
        public async Task<SendHealthLogToDoctorResult> Handle(SendHealthLogToDoctorCommand command, CancellationToken cancellationToken)
        {
            if(await repository.GetByIdAsync<ApplicationUser>(command.DoctorId) == null)
            {
                throw new DoctorNotFoundException(command.DoctorId);
            }

            if(await repository.GetByIdAsync<UserHealthLog>(command.UserHealthLogId) == null)
            {
                throw new UserHealthLogNotFoundException(command.UserHealthLogId);
            }

            var userHealthLogToDoctor = new UserHealthLogToDoctor
            {
                DoctorId = command.DoctorId,
                UserHealthLogId = command.UserHealthLogId
            };

            await repository.AddAsync(userHealthLogToDoctor);
            await repository.SaveChangesAsync();

            await notificationService.SendNotificationAsync(command.DoctorId, 
                "A new health log has been sent to you by a user.", NotificationType.HealthLog);

            return new SendHealthLogToDoctorResult(true, "Health log sent to doctor successfully.");
        }
    }
}
