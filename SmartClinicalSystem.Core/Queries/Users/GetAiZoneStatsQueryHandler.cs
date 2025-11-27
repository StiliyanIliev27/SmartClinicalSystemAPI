using BuildingBlock.BuildingBlocks.CQRS;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.DTOs.User;
using SmartClinicalSystem.Core.Helpers;

namespace SmartClinicalSystem.Core.Queries.Users
{
    public record GetAiZoneQuery(string UserId) : IQuery<GetAiZoneQueryResult>;
    public record GetAiZoneQueryResult(AiZoneDashboardDto Result);
    public class GetAiZoneStatsQueryHandler(IRepository repository) : IQueryHandler<GetAiZoneQuery, GetAiZoneQueryResult>
    {
        public async Task<GetAiZoneQueryResult> Handle(GetAiZoneQuery query, CancellationToken cancellationToken)
        {
            var aiConsultationsCounter = await DashboardsHelper.GetAiConsultationsAsync(query.UserId, repository);
            var aiLatestDates = await DashboardsHelper.GetLatestDates(query.UserId, repository);

            return new GetAiZoneQueryResult
            (
                new AiZoneDashboardDto
                {
                    TotalDiagnoses = aiConsultationsCounter.TotalDiagnoses,
                    TotalComparisons = aiConsultationsCounter.TotalComparisons,
                    TotalSummaryChecks = aiConsultationsCounter.TotalSummaryChecks,
                    LastSummaryCheckDate = aiLatestDates.LastSummaryCheckDate,
                    LastComparisonDate = aiLatestDates.LastComparisonDate,
                    LastDiagnosisDate = aiLatestDates.LastDiagnosisDate
                }
            );
        }
    }
}
