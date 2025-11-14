namespace SmartClinicalSystem.Core.DTOs.Doctor
{
    public abstract class InputMedicalReceiptDataDto
    {
        public string Diagnosis { get; set; } = null!;
        public IEnumerable<MedicineInfoDto> Medicines { get; set; } = new HashSet<MedicineInfoDto>();
        public string? Advice { get; set; }
        public string? ExpirationDate { get; set; }
    }

    public class CreateMedicalReceiptDto : InputMedicalReceiptDataDto
    {
        public string PatientId { get; set; } = null!;
        public string DoctorId { get; set; } = null!;    
        public bool UseAiDiagnosis { get; set; }
    }

    public class UpdateMedicalReceiptDto : InputMedicalReceiptDataDto
    {
        public string MedicalReceiptId { get; set; } = null!;
    }

    public class MedicineInfoDto
    {
        public string MedicineId { get; set; } = null!;
        public int Quantity { get; set; }
        public int DurationDays { get; set; }
        public string? DosageInstructions { get; set; }
    }
}
