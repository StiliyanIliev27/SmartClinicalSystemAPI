using SmartClinicalSystem.Infrastructure.Data.Enums;
using SmartClinicalSystem.Infrastructure.Data.Interfaces;

namespace SmartClinicalSystem.Infrastructure.Data.Models
{
    public class PromptTemplate : IAuditableEntity, IDeletableEntity
    {
        public PromptTemplate()
        {
            PromptTemplateId = Guid.NewGuid().ToString();
        }
        public string PromptTemplateId { get; set; } 
        public string? Name { get; set; }
        public string? Description { get; set; }
        public PromptTemplateType Type { get; set; }  // e.g. "Diagnose", "Summary", "Chatbot" -> you can check the enum
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
