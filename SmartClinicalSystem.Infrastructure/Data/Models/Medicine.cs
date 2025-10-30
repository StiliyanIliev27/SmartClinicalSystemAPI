using SmartClinicalSystem.Infrastructure.Data.Enums;
using SmartClinicalSystem.Infrastructure.Data.Interfaces;

namespace SmartClinicalSystem.Infrastructure.Data.Models
{
    public class Medicine : IAuditableEntity, IDeletableEntity
    {
        public Medicine()
        {
            MedicineId = Guid.NewGuid().ToString();
        }
        public string MedicineId { get; set; }
        // Core details
        public string GenericName { get; set; } = null!;
        public MedicineCategory Category { get; set; }
        public string DosageForm { get; set; } = null!;
        public string Strength { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;

        // Commercial / management info
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Extended medical info
        public string? Description { get; set; }               // AI can summarize this
        public string? Indications { get; set; }               // What conditions it treats
        public string? Contraindications { get; set; }         // When not to use
        public string? SideEffects { get; set; }               // Common side effects
        public string? Precautions { get; set; }               // Important notes

        // AI-related metadata
        public string? AiSummary { get; set; }                 // GPT-generated readable summary
        public DateTime? LastAiUpdated { get; set; }           // When AI last processed it

        // Soft delete & auditing
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
