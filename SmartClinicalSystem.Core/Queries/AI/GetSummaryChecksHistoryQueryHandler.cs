using BuildingBlock.BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClinicalSystem.Core.Queries.AI
{
    public record GetSummaryChecksQuery(string UserId, int Period) : IQuery<GetSummaryChecksResult>;
    public record GetSummaryChecksResult(IEnumerable<AiSummaryCheckerConsultation> Result);
    public class GetSummaryChecksHistoryQueryHandler(IRepository repository) 
        : IQueryHandler<GetSummaryChecksQuery, GetSummaryChecksResult>
    {
        public async Task<GetSummaryChecksResult> Handle(GetSummaryChecksQuery query, CancellationToken cancellationToken)
        {
            var cutoffDate = DateTime.UtcNow.AddDays(-query.Period);

            var result = await repository.AllReadOnly<AiSummaryCheckerConsultation>()
                    .Where(c => c.UserId == query.UserId
                        && c.CreatedAt >= cutoffDate)
                    .ToListAsync(cancellationToken);

            return new GetSummaryChecksResult(result);
        }
    }
}
