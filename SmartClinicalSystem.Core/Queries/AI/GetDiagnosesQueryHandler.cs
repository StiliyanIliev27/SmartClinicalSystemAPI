using BuildingBlock.BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Queries.AI
{
    public record GetDiagnosesQuery(string UserId) : IQuery<GetDiagnosesResult>;
    public record GetDiagnosesResult(IEnumerable<AiDiagnosisConsultation> Result);
    public class GetDiagnosesQueryHandler(IRepository repository) : IQueryHandler<GetDiagnosesQuery, GetDiagnosesResult>
    {
        public async Task<GetDiagnosesResult> Handle(GetDiagnosesQuery query, CancellationToken cancellationToken)
        {
            return new GetDiagnosesResult(
                await repository.AllReadOnly<AiDiagnosisConsultation>()
                .Where(c => c.UserId == query.UserId)
                .ToListAsync(cancellationToken: cancellationToken)
            );
        }
    }
}
