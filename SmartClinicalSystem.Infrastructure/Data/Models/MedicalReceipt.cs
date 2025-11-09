using SmartClinicalSystem.Infrastructure.Data.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClinicalSystem.Infrastructure.Data.Models
{
    public class MedicalReceipt : IAuditableEntity, IDeletableEntity
    {
        public MedicalReceipt()
        {
            MedicalReceiptId = Guid.NewGuid().ToString();
            MedicalReceiptsMedicines = new HashSet<MedicalReceiptMedicine>();
        }

        public string MedicalReceiptId { get; set; }

        public string DoctorId { get; set; } = null!;
        public ApplicationUser Doctor { get; set; } = null!;

        public string PatientId { get; set; } = null!;
        public ApplicationUser Patient { get; set; } = null!;

        public ICollection<MedicalReceiptMedicine> MedicalReceiptsMedicines { get; set; }

        public string Diagnosis { get; set; } = null!;
        public string? Advice { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;
        public DateTime? ExpirationDate { get; set; }

        public string? AiDiagnosis { get; set; }
        public string? AiAdvice { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }

}
