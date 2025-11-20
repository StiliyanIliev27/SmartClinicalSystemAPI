using SmartClinicalSystem.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClinicalSystem.Infrastructure.Data.Models
{
    public class Notification
    {
        public string NotificationId { get; set; } = Guid.NewGuid().ToString();
        public NotificationType NotificationType { get; set; }
        public string Message { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(RecipientId))]
        public string RecipientId { get; set; } = string.Empty;
        public ApplicationUser? Recipient { get; set; }
        public DateTime SendAt { get; set; }
    }
}
