using BuildingBlock.BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.DTOs.Doctor;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Queries.Doctors
{
    public record GetMedicalReceiptsQuery(
        int? PageNumber = 1, 
        int? PageSize = 10, 
        string? PatientId = "",
        string? DoctorId = "") : IQuery<GetMedicalReceiptsResult>;
    public record GetMedicalReceiptsResult(IEnumerable<GetMedicalReceiptResultDto> Result);
    public class GetMedicalReceiptsQueryHandler(IRepository repository) : IQueryHandler<GetMedicalReceiptsQuery, GetMedicalReceiptsResult>
    {
        public async Task<GetMedicalReceiptsResult> Handle(GetMedicalReceiptsQuery query, CancellationToken cancellationToken)
        {
            var pageNumber = query.PageNumber ?? 1;
            var pageSize = query.PageSize ?? 10;

            var medicalReceipts = await repository.AllReadOnly<MedicalReceipt>()
                .Include(mr => mr.MedicalReceiptsMedicines)
                .ThenInclude(mr => mr.Medicine)
                .ToListAsync(cancellationToken: cancellationToken);

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

            var result = medicalReceipts.Select(mr => new GetMedicalReceiptResultDto()
            {
                MedicalReceiptId = mr.MedicalReceiptId,
                DoctorId = mr.DoctorId,
                PatientId = mr.PatientId,
                Diagnosis = mr.Diagnosis,
                Advice = mr.Advice,
                IssueDate = mr.IssueDate,
                ExpirationDate = mr.ExpirationDate,
                AiDiagnosis = mr.AiDiagnosis,
                AiAdvice = mr.AiAdvice,
                MedicalReceiptsMedicines = mr.MedicalReceiptsMedicines.Select(rm => new GetMedicalReceiptMedicineDto
                {
                    MedicineId = rm.MedicineId,
                    GenericName = rm.Medicine.GenericName,
                    Quantity = rm.Quantity,
                    DurationDays = rm.DurationDays,
                    DosageInstructions = rm.DosageInstructions
                }).ToList()
            })
            .ToList();

            return new GetMedicalReceiptsResult(result);
        }
    }
}
