using BuildingBlock.BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Queries.Medicines
{
    public record MedicinesDto(
        IEnumerable<Medicine> Medicines,
        int TotalPages
    );
    public record GetMedicinesQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetMedicinesResult>;
    public record GetMedicinesResult(MedicinesDto Result);
    public class GetMedicinesQueryHandler(IRepository repository)
        : IQueryHandler<GetMedicinesQuery, GetMedicinesResult>
    {
        public async Task<GetMedicinesResult> Handle(GetMedicinesQuery query, CancellationToken cancellationToken)
        {
            var pageNumber = query.PageNumber ?? 1;
            var pageSize = query.PageSize ?? 10;

            // Get total count of ALL medicines BEFORE pagination
            var totalCount = await repository.AllReadOnly<Medicine>()
                .CountAsync(cancellationToken);

            // Calculate total pages (round up)
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            // Get paginated medicines
            var medicines = await repository.AllReadOnly<Medicine>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new GetMedicinesResult(new MedicinesDto(medicines, totalPages));
        }
    }
}
