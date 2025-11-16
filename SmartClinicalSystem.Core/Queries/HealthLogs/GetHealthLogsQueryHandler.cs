using BuildingBlock.BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Queries.HealthLogs
{
    public record GetHealthLogsQuery(string PatientId) : IQuery<GetHealthLogsResult>;
    public record GetHealthLogsResult(IEnumerable<UserHealthLog> Result);
    public class GetHealthLogsQueryHandler(IRepository repository) : IQueryHandler<GetHealthLogsQuery, GetHealthLogsResult>
    {
        public async Task<GetHealthLogsResult> Handle(GetHealthLogsQuery query, CancellationToken cancellationToken)
        {
            var result = await repository.AllReadOnly<UserHealthLog>()
                .Where(hl => hl.UserId == query.PatientId).ToListAsync(cancellationToken);

            return new GetHealthLogsResult(result);
        }
    }
}
