namespace SmartClinicalSystem.Core.DTOs.AI
{
    public class ComparedMedicineDto
    {
        public string MedicineId { get; set; } = null!;
        public int MatchScore { get; set; }
        public IEnumerable<string> MatchingKeywords { get; set; } = new List<string>();
    }
}
