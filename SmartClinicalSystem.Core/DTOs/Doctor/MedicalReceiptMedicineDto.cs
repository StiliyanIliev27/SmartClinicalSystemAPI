namespace SmartClinicalSystem.Core.DTOs.Doctor
{
    public class UpdateMedicalReceiptMedicineDto
    {
        public string MedicineId { get; set; } = null!;
        public int Quantity { get; set; }
        public int DurationDays { get; set; }
        public string? DosageInstructions { get; set; }
    }
    public class GetMedicalReceiptMedicineDto : UpdateMedicalReceiptMedicineDto
    {
        public string GenericName { get; set; } = null!;
    }
}
