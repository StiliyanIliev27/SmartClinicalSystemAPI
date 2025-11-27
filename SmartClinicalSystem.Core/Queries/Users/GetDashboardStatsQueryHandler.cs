using BuildingBlock.BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.DTOs.User;
using SmartClinicalSystem.Core.Exceptions.NotFound;
using SmartClinicalSystem.Core.Helpers;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Queries.Users
{
    public record GetDashboardStatsQuery(string UserId) : IQuery<GetDashboardStatsResult>;
    public record GetDashboardStatsResult(UserDashboardDto Result);
    public class GetDashboardStatsQueryHandler(IRepository repository) 
        : IQueryHandler<GetDashboardStatsQuery, GetDashboardStatsResult>
    {
        public async Task<GetDashboardStatsResult> Handle(GetDashboardStatsQuery query, CancellationToken cancellationToken)
        {
            var user = await repository.GetByIdAsync<ApplicationUser>(query.UserId);

            if(user == null)
            {
                throw new UserNotFoundException(query.UserId);
            }

            var healthLogs = await repository.AllReadOnly<UserHealthLog>()
                .Include(hl => hl.UserHealthLogToDoctor)
                .Where(hl => hl.UserId == query.UserId)
                .ToListAsync(cancellationToken);

            var aiConsultationsCounter = await DashboardsHelper.GetAiConsultationsAsync(query.UserId, repository);

            var result = new UserDashboardDto()
            {
                TotalHealthLogs = healthLogs.Count,
                RecentHealthLogs = healthLogs
                    .OrderByDescending(hl => hl.CreatedAt)
                    .Take(3)
                    .Select(hl => new RecentHealthLogDto
                    {
                        HealthLogId = hl.Id,
                        Symptoms = hl.Symptoms!,
                        PainLevel = hl.PainLevel,
                        CreatedAt = hl.CreatedAt.ToString("dd-MM-yyyy"),
                        Status = hl.UserHealthLogToDoctor == null ? "Not Sent" :
                            hl.UserHealthLogToDoctor.IsViewedByDoctor == true ? "Under Review" : "Not Seen Yet"
                    })
                    .ToList(),
                TotalAiConsultations = aiConsultationsCounter.TotalDiagnoses + aiConsultationsCounter.TotalComparisons + aiConsultationsCounter.TotalSummaryChecks,
                ActivePrescriptions = await repository.AllReadOnly<Medicine>()
                    .CountAsync(cancellationToken: cancellationToken),
                PendingReviews = await repository.AllReadOnly<UserHealthLogToDoctor>()
                    .Where(hl => hl.UserHealthLog!.UserId == query.UserId && !hl.IsViewedByDoctor)
                    .CountAsync(cancellationToken: cancellationToken),
                HealthSummary = new HealthSummaryDto()
                {
                    AveragePainLevel = healthLogs.Count != 0 ? (int)healthLogs.Average(hl => hl.PainLevel ?? 0) : 0,
                    MostCommonSymptoms = healthLogs
                        .Where(hl => !string.IsNullOrEmpty(hl.Symptoms))
                        .GroupBy(hl => hl.Symptoms)
                        .OrderByDescending(g => g.Count())
                        .Take(3)
                        .Select(g => g.Key!)
                        .ToArray(),
                    AverageTemperature = healthLogs.Count != 0 ? (int)healthLogs.Average(hl => hl.Temperature ?? 0) : 36.8,
                    HealthScore = healthLogs.Count != 0 ? 100 - (int)healthLogs.Average(hl => hl.PainLevel ?? 0) * 5 : null,
                    LastLogDate = healthLogs.Count != 0 ? healthLogs.Max(hl => hl.CreatedAt).ToString("dd-MM-yyyy") : null,
                    DaysSinceLastLog = healthLogs.Count != 0 ? (DateTime.Now - healthLogs.Max(hl => hl.CreatedAt)).Days : null,
                    AveragePainLevelTrend = GetPainLevelTrend(healthLogs)
                },
                Insights = GenerateInsights(healthLogs)
            };

            return new GetDashboardStatsResult(result);
        }

        public static string GetPainLevelTrend(List<UserHealthLog> healthLogs)
        {
            if (healthLogs.Count < 2)
                return "Stable";

            var sortedLogs = healthLogs.OrderBy(hl => hl.CreatedAt).ToList();
            var firstHalfAvg = sortedLogs.Take(sortedLogs.Count / 2).Average(hl => hl.PainLevel ?? 0);
            var secondHalfAvg = sortedLogs.Skip(sortedLogs.Count / 2).Average(hl => hl.PainLevel ?? 0);

            if (secondHalfAvg > firstHalfAvg + 1)
                return "Increasing";
            else if (secondHalfAvg < firstHalfAvg - 1)
                return "Decreasing";
            else
                return "Stable";
        }

        private static InsightsDto GenerateInsights(List<UserHealthLog> logs)
        {
            if (logs.Count < 2)
                return new InsightsDto
                {
                    PainLevelIncreased = false,
                    NeedsAttention = false,
                    Recommendations = new[] { "Keep logging your symptoms regularly." }
                };

            var sorted = logs.OrderByDescending(l => l.CreatedAt).ToList();
            var latest = sorted[0];
            var previous = sorted[1];

            bool painIncreased = (latest.PainLevel ?? 0) > (previous.PainLevel ?? 0);

            bool needsAttention =
                (latest.PainLevel ?? 0) >= 7 ||
                (latest.Temperature ?? 36) >= 38.0 ||
                (!string.IsNullOrEmpty(latest.Symptoms) && latest.Symptoms.Contains("chest", StringComparison.OrdinalIgnoreCase)) ||
                (DateTime.Now - latest.CreatedAt).Days > 7;

            var recommendations = new List<string>();

            if (painIncreased) recommendations.Add("Your pain level increased—consider contacting your doctor.");
            if (needsAttention) recommendations.Add("Recent symptoms suggest you may need medical attention.");
            recommendations.Add("Maintain hydration and rest well.");
            recommendations.Add("Continue tracking your symptoms daily.");

            return new InsightsDto
            {
                PainLevelIncreased = painIncreased,
                NeedsAttention = needsAttention,
                Recommendations = [.. recommendations]
            };
        }

    }
}
