using SmartClinicalSystem.Infrastructure.Data.Interfaces;

namespace SmartClinicalSystem.Infrastructure.Data.Models
{
    public abstract class AiConsultation : IAuditableEntity
    {
        public AiConsultation()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string UserId { get; set; } = null!;
        public string AiResponseJson { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
