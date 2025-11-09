namespace SmartClinicalSystem.Core.DTOs.Doctor
{
    public class CreateMedicalReceiptDto
    {
        public string PatientId { get; set; } = null!;
        public string DoctorId { get; set; } = null!;
        public string Diagnosis { get; set; } = null!;
        public IEnumerable<string> MedicineIds { get; set; } = new HashSet<string>();
        public int Quantity { get; set; }
        public int DurationDays { get; set; }
        public bool UseAiDiagnosis { get; set; }
        public string? DosageInstructions { get; set; }
        public string? Advice { get; set; }
        public string? ExpirationDate { get; set; }
    }
}
