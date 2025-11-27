using BuildingBlock.BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Queries.AI
{
    public record GetComparisonsQuery(string UserId) : IQuery<GetComparisonsResult>;
    public record GetComparisonsResult(IEnumerable<AiCompareConsultation> Result);
    public class GetComparisonsQueryHandler(IRepository repository) : IQueryHandler<GetComparisonsQuery, GetComparisonsResult>
    {
        public async Task<GetComparisonsResult> Handle(GetComparisonsQuery query, CancellationToken cancellationToken)
        {
            return new GetComparisonsResult(
                await repository.AllReadOnly<AiCompareConsultation>()
                .Where(c => c.UserId == query.UserId)
                .ToListAsync(cancellationToken: cancellationToken)
            );
        }
    }
}
