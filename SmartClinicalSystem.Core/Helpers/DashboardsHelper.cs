using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Helpers
{
    public class AiConsultationsCounter
    {
        public int TotalDiagnoses { get; set; }
        public int TotalComparisons { get; set; }
        public int TotalSummaryChecks { get; set; }
    }

    public class AiConsultationsLastDates
    {
        public string LastDiagnosisDate { get; set; } = string.Empty;
        public string LastComparisonDate { get; set; } = string.Empty;
        public string LastSummaryCheckDate { get; set; } = string.Empty;
    }
    public static class DashboardsHelper
    {
        public static async Task<AiConsultationsCounter> GetAiConsultationsAsync(string userId, IRepository repository)
        {
            var aiDiagnosisConsultationsCount = await repository.AllReadOnly<AiDiagnosisConsultation>()
                .Where(ac => ac.UserId == userId)
                .CountAsync();

            var aiCompareConsultationsCount = await repository.AllReadOnly<AiCompareConsultation>()
                .Where(ac => ac.UserId == userId)
                .CountAsync();

            var aiSummaryCheckerConsultationsCount = await repository.AllReadOnly<AiSummaryCheckerConsultation>()
                .Where(ac => ac.UserId == userId)
                .CountAsync();

            return new AiConsultationsCounter
            {
                TotalDiagnoses = aiDiagnosisConsultationsCount,
                TotalComparisons = aiCompareConsultationsCount,
                TotalSummaryChecks = aiSummaryCheckerConsultationsCount
            };
        }

        public static async Task<AiConsultationsLastDates> GetLatestDates(string userId, IRepository repository)
        {
            var lastDiagnosisDate = await repository.AllReadOnly<AiDiagnosisConsultation>()
                .Where(ac => ac.UserId == userId)
                .OrderByDescending(ac => ac.CreatedAt)
                .Select(ac => ac.CreatedAt.ToString("dd-MM-yyyy"))
                .FirstOrDefaultAsync() ?? string.Empty;

            var lastComparisonDate = await repository.AllReadOnly<AiCompareConsultation>()
                .Where(ac => ac.UserId == userId)
                .OrderByDescending(ac => ac.CreatedAt)
                .Select(ac => ac.CreatedAt.ToString("dd-MM-yyyy"))
                .FirstOrDefaultAsync() ?? string.Empty;

            var lastSummaryCheckDate = await repository.AllReadOnly<AiSummaryCheckerConsultation>()
                .Where(ac => ac.UserId == userId)
                .OrderByDescending(ac => ac.CreatedAt)
                .Select(ac => ac.CreatedAt.ToString("dd-MM-yyyy"))
                .FirstOrDefaultAsync() ?? string.Empty;

            return new AiConsultationsLastDates
            {
                LastComparisonDate = lastComparisonDate,
                LastDiagnosisDate = lastDiagnosisDate,
                LastSummaryCheckDate = lastSummaryCheckDate
            };
        }
    }
}
