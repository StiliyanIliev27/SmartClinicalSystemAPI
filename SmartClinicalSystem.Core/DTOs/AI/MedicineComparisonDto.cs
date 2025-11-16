namespace SmartClinicalSystem.Core.DTOs.AI
{
    public class MedicineComparisonDto
    {
        public string Diagnosis { get; set; } = null!;
        public ComparedMedicineDto A { get; set; } = null!;
        public ComparedMedicineDto B { get; set; } = null!;
        public string BetterMedicineId { get; set; } = null!;
        public string Explanation { get; set; } = null!;
    }
}
