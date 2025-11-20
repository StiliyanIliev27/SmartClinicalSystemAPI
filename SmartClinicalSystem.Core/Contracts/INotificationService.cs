using SmartClinicalSystem.Infrastructure.Data.Enums;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Contracts
{
    public interface INotificationService
    {
        Task SendNotificationAsync(string recipientId, string message, NotificationType notificationType);
        Task<IEnumerable<Notification>> GetNotificationsByUser(string userId);
    }
}
