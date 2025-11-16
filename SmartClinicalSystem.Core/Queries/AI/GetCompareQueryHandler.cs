using BuildingBlock.BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.DTOs.AI;
using SmartClinicalSystem.Core.Exceptions.NotFound;
using SmartClinicalSystem.Infrastructure.Data.Models;
using System.Text.Json;

namespace SmartClinicalSystem.Core.Queries.AI
{
    public record GetCompareQuery(string FirstMedicineId, string SecondMedicineId, string Diagnosis, string UserId) : IQuery<GetCompareResult>;
    public record GetCompareResult(MedicineComparisonDto ComparisonReport);
    public class GetCompareQueryHandler(IRepository repository, ISmartService smartService) : IQueryHandler<GetCompareQuery, GetCompareResult>
    {
        public async Task<GetCompareResult> Handle(GetCompareQuery query, CancellationToken cancellationToken)
        {
            var firstMedicine = await repository.AllReadOnly<Medicine>()
                .FirstOrDefaultAsync(m => m.MedicineId == query.FirstMedicineId, cancellationToken);

            var secondMedicine = await repository.AllReadOnly<Medicine>()
                .FirstOrDefaultAsync(m => m.MedicineId == query.SecondMedicineId, cancellationToken);

            if(firstMedicine == null || secondMedicine == null)
            {
                throw new MedicineNotFoundException(firstMedicine == null ? query.FirstMedicineId : query.SecondMedicineId);
            }

            var result = await smartService.GenerateComparisonReport(query.FirstMedicineId, query.SecondMedicineId, query.Diagnosis);

            var consultation = new AiCompareConsultation()
            {
                FirstMedicineId = query.FirstMedicineId,
                SecondMedicineId = query.SecondMedicineId,
                AiResponseJson = JsonSerializer.Serialize(result),
                UserId = query.UserId
            };

            await repository.AddAsync(consultation);
            await repository.SaveChangesAsync();
           
            return new GetCompareResult(result);
        }
    }
}
