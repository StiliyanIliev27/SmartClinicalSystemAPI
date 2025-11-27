using BuildingBlock.BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.Exceptions.NotFound;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Queries.HealthLogs
{
    public record GetHealthLogByIdQuery(string HealthLogId) : IQuery<GetHealthLogByIdResult>;
    public record GetHealthLogByIdResult(UserHealthLog Result);
    public class GetHealthLogByIdQueryHandler(IRepository repository) : IQueryHandler<GetHealthLogByIdQuery, GetHealthLogByIdResult>
    {
        public async Task<GetHealthLogByIdResult> Handle(GetHealthLogByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await repository.AllReadOnly<UserHealthLog>()
                .Where(hl => hl.Id == query.HealthLogId)
                .FirstOrDefaultAsync();

            if(result == null)
            {
                throw new UserHealthLogNotFoundException(query.HealthLogId);
            }

            return new GetHealthLogByIdResult(result);
        }
    }
}
