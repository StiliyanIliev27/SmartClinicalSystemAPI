namespace SmartClinicalSystem.Core.Helpers
{
    public class AiDiagnosisIntermediate
    {
        public string PossibleConditions { get; set; } = string.Empty;
        public List<string> RecommendedMedicineIds { get; set; } = new();
        public string Advice { get; set; } = string.Empty;
    }
}
