namespace SmartClinicalSystem.Core.DTOs.User
{
    public class AiZoneDashboardDto
    {
        public int TotalDiagnoses { get; set; }
        public int TotalComparisons { get; set; }
        public int TotalSummaryChecks { get; set; }
        public string LastDiagnosisDate { get; set; } = null!;
        public string LastComparisonDate { get; set; } = null!;
        public string LastSummaryCheckDate { get; set; } = null!;
    }
}
