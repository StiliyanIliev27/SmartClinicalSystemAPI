using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClinicalSystem.Infrastructure.Data.Models
{
    public class MedicalReceiptMedicine
    {
        [Key]
        public string ReceiptMedicineId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [ForeignKey(nameof(MedicalReceiptId))]
        public string MedicalReceiptId { get; set; } = null!;
        public MedicalReceipt MedicalReceipt { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(MedicineId))]
        public string MedicineId { get; set; } = null!;
        public Medicine Medicine { get; set; } = null!;

        public int Quantity { get; set; }
        public string? DosageInstructions { get; set; }
        public int DurationDays { get; set; }
    }
}
