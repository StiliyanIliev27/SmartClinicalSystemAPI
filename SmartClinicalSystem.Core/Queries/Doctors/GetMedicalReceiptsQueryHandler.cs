using BuildingBlock.BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Queries.Doctors
{
    public record GetMedicalReceiptsQuery(
        int? PageNumber = 1, 
        int? PageSize = 10, 
        string? PatientId = "",
        string? DoctorId = "") : IQuery<GetMedicalReceiptsResult>;
    public record GetMedicalReceiptsResult(IEnumerable<MedicalReceipt> Result);
    public class GetMedicalReceiptsQueryHandler(IRepository repository) : IQueryHandler<GetMedicalReceiptsQuery, GetMedicalReceiptsResult>
    {
        public async Task<GetMedicalReceiptsResult> Handle(GetMedicalReceiptsQuery query, CancellationToken cancellationToken)
        {
            var pageNumber = query.PageNumber ?? 1;
            var pageSize = query.PageSize ?? 10;

            var medicalReceipts = await repository.All<MedicalReceipt>().ToListAsync(cancellationToken: cancellationToken);

            if (!string.IsNullOrEmpty(query.PatientId))
            {
                medicalReceipts = medicalReceipts
                    .Where(mr => mr.PatientId == query.PatientId)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(query.DoctorId))
            {
                medicalReceipts = medicalReceipts
                    .Where(mr => mr.DoctorId == query.DoctorId)
                    .ToList();
            }

            medicalReceipts = medicalReceipts
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new GetMedicalReceiptsResult(medicalReceipts);
        }
    }
}
