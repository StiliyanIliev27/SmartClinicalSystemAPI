using BuildingBlock.BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Queries.Medicines
{
    public record GetMedicinesQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetMedicinesResult>;
    public record GetMedicinesResult(IEnumerable<Medicine> Medicines);
    public class GetMedicinesQueryHandler(IRepository repository)
        : IQueryHandler<GetMedicinesQuery, GetMedicinesResult>
    {
        public async Task<GetMedicinesResult> Handle(GetMedicinesQuery query, CancellationToken cancellationToken)
        {
            var pageNumber = query.PageNumber ?? 1;
            var pageSize = query.PageSize ?? 10;

            var medicines = await repository.AllReadOnly<Medicine>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new GetMedicinesResult(medicines);
        }
    }
}
