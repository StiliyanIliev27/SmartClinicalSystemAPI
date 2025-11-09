namespace SmartClinicalSystem.Infrastructure.Data.Models
{
    public class MedicalReceiptMedicine
    {
        public string ReceiptMedicineId { get; set; } = Guid.NewGuid().ToString();

        public string MedicalReceiptId { get; set; } = null!;
        public MedicalReceipt MedicalReceipt { get; set; } = null!;

        public string MedicineId { get; set; } = null!;
        public Medicine Medicine { get; set; } = null!;

        public int Quantity { get; set; }
        public string? DosageInstructions { get; set; }
        public int DurationDays { get; set; }
    }
}
