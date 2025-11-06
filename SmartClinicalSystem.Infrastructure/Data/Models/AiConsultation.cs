using SmartClinicalSystem.Infrastructure.Data.Enums;
using SmartClinicalSystem.Infrastructure.Data.Interfaces;

namespace SmartClinicalSystem.Infrastructure.Data.Models
{
    public class AiConsultation : IAuditableEntity
    {
        public AiConsultation()
        {
            AiConsultationId = Guid.NewGuid().ToString();
        }
        public string AiConsultationId { get; set; }
        public string UserId { get; set; } = null!;
        public string? Symptoms { get; set; }
        public ConsultationCategory Category { get; set; }
        public string AiResponseJson { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
