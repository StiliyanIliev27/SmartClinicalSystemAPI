using BuildingBlock.BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Infrastructure.Data.Models;
using System.Text.Json;

namespace SmartClinicalSystem.Core.Queries.AI
{
    public record GetSummaryCheckQuery(int Period, string UserId) : IQuery<GetSummaryCheckResult>;
    public record GetSummaryCheckResult(string Summary);
    public class GetSummaryCheckQueryHandler(ISmartService smartService, IRepository repository)
        : IQueryHandler<GetSummaryCheckQuery, GetSummaryCheckResult>
    {
        public async Task<GetSummaryCheckResult> Handle(GetSummaryCheckQuery query, CancellationToken cancellationToken)
        {
            var startDate = DateTime.Now.AddDays(-query.Period);

            var medicalReceipts = await repository.AllReadOnly<MedicalReceipt>()
                .Where(mr => mr.PatientId == query.UserId && mr.IssueDate >= startDate)
                .ToListAsync(cancellationToken);

            var healthLogs = await repository.AllReadOnly<UserHealthLog>()
                .Where(hl => hl.UserId == query.UserId && hl.CreatedAt >= startDate)
                .ToListAsync(cancellationToken);

            if(!medicalReceipts.Any() && !healthLogs.Any())
            {
                return new GetSummaryCheckResult("No medical receipts and health logs registered to the moment!");
            }

            var result = await smartService.SummarizeMedicalDataAsync(medicalReceipts, healthLogs);

            var summaryConsultation = new AiSummaryCheckerConsultation()
            {
                AiResponseJson = JsonSerializer.Serialize(result),
                UserId = query.UserId,
                InputPeriod = query.Period
            };

            await repository.AddAsync(summaryConsultation);
            await repository.SaveChangesAsync();

            return new GetSummaryCheckResult(result);
        }
    }
}
