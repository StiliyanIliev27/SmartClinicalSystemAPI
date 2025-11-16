using BuildingBlock.BuildingBlocks.CQRS;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.Exceptions;
using SmartClinicalSystem.Core.Exceptions.NotFound;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Queries.Medicines
{
    public record GetMedicineByIdQuery(string Id) : IQuery<GetMedicineByIdResult>;
    public record GetMedicineByIdResult(Medicine Result);
    public class GetMedicineByIdQueryHandler(IRepository repository)
        : IQueryHandler<GetMedicineByIdQuery, GetMedicineByIdResult>
    {
        public async Task<GetMedicineByIdResult> Handle(GetMedicineByIdQuery query, CancellationToken cancellationToken)
        {
            var medicine = await repository.GetByIdAsync<Medicine>(query.Id);

            if (medicine is null)
            {
                throw new MedicineNotFoundException(query.Id);
            }

            return new GetMedicineByIdResult(medicine);
        }
    }
}
