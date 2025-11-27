namespace SmartClinicalSystem.Core.DTOs.User
{
    public class UserDashboardDto
    {
        public int TotalHealthLogs { get; set; }
        public int TotalAiConsultations { get; set; }
        public int ActivePrescriptions { get; set; }
        public int PendingReviews { get; set; }
        public HealthSummaryDto HealthSummary { get; set; } = null!;
        public IEnumerable<RecentHealthLogDto> RecentHealthLogs { get; set; } = new HashSet<RecentHealthLogDto>();
        public InsightsDto? Insights { get; set; }
    }

    public class HealthSummaryDto
    {
        public int AveragePainLevel { get; set; }
        public string AveragePainLevelTrend { get; set; } = string.Empty;
        public double AverageTemperature { get; set; }
        public string[] MostCommonSymptoms { get; set; } = [];
        public int? HealthScore { get; set; }
        public string? LastLogDate { get; set; }
        public int? DaysSinceLastLog { get; set; }
    }

    public class RecentHealthLogDto
    {
        public string HealthLogId { get; set; } = string.Empty;
        public string Symptoms { get; set; } = string.Empty;
        public int? PainLevel { get; set; }
        public string CreatedAt { get; set; } = string.Empty;
        public string? Status { get; set; }
    }

    public class InsightsDto
    {
        public bool PainLevelIncreased { get; set; }
        public bool NeedsAttention { get; set; }
        public string[] Recommendations { get; set; } = [];
    }

}
