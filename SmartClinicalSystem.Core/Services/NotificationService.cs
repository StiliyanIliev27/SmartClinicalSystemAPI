using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Infrastructure.Data.Enums;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Services
{
    public class NotificationService(IRepository repository) : INotificationService
    {
        public async Task<IEnumerable<Notification>> GetNotificationsByUser(string userId)
        {
            return await repository.AllReadOnly<Notification>()
                .Where(n => n.RecipientId == userId)
                .ToListAsync();
        }

        public async Task SendNotificationAsync(string recipientId, string message, NotificationType notificationType)
        {
            if(await repository.GetByIdAsync<ApplicationUser>(recipientId) == null)
            {
                throw new Exception("Recipient user does not exist.");
            }

            var notification = new Notification
            {
                RecipientId = recipientId,
                Message = message,
                NotificationType = notificationType,
                SendAt = DateTime.Now
            };

            await repository.AddAsync(notification);
            await repository.SaveChangesAsync();
        }
    }
}
