using BuildingBlock.BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.DTOs.Doctor;
using SmartClinicalSystem.Core.Exceptions.NotFound;
using SmartClinicalSystem.Infrastructure.Data.Models;
using static SmartClinicalSystem.Core.Helpers.DateFormatHelper;

namespace SmartClinicalSystem.Core.Commands.Doctors
{
    public record UpdateMedicalReceiptCommand(UpdateMedicalReceiptDto UpdateMedicalReceiptDto) : ICommand<UpdateMedicalReceiptResult>;
    public record UpdateMedicalReceiptResult(UpdateMedicalReceiptResultDto Result);
    public class UpdateMedicalReceiptCommandHandler(IRepository repository)
        : ICommandHandler<UpdateMedicalReceiptCommand, UpdateMedicalReceiptResult>
    {
        public async Task<UpdateMedicalReceiptResult> Handle(UpdateMedicalReceiptCommand command, CancellationToken cancellationToken)
        {
            var dto = command.UpdateMedicalReceiptDto;

            var medicalReceipt = await repository.All<MedicalReceipt>()
                .Include(mr => mr.MedicalReceiptsMedicines)
                .FirstOrDefaultAsync(mr => mr.MedicalReceiptId == dto.MedicalReceiptId, 
                    cancellationToken: cancellationToken);

            if (medicalReceipt == null)
                throw new MedicalReceiptNotFoundException(dto.MedicalReceiptId);

            // Load existing medicines into memory
            var existingMedicines = medicalReceipt.MedicalReceiptsMedicines.ToList();

            foreach (var medDto in dto.Medicines)
            {
                // Check if medicine exists
                var medicineExists = await repository.GetByIdAsync<Medicine>(medDto.MedicineId);
                if (medicineExists == null)
                    throw new MedicineNotFoundException(medDto.MedicineId);

                // Try to find existing medicine relation
                var existing = existingMedicines.FirstOrDefault(x => x.MedicineId == medDto.MedicineId);

                if (existing != null)
                {
                    // Update existing record
                    existing.Quantity = medDto.Quantity;
                    existing.DurationDays = medDto.DurationDays;
                    existing.DosageInstructions = medDto.DosageInstructions;
                }
                else
                {
                    // Add new record
                    var newItem = new MedicalReceiptMedicine
                    {
                        MedicalReceiptId = medicalReceipt.MedicalReceiptId,
                        MedicineId = medDto.MedicineId,
                        Quantity = medDto.Quantity,
                        DurationDays = medDto.DurationDays,
                        DosageInstructions = medDto.DosageInstructions
                    };

                    await repository.AddAsync(newItem);
                    medicalReceipt.MedicalReceiptsMedicines.Add(newItem);
                }
            }

            // Update main fields
            medicalReceipt.Diagnosis = dto.Diagnosis;
            medicalReceipt.Advice = dto.Advice;
            medicalReceipt.UpdatedAt = DateTime.Now;

            if (!string.IsNullOrEmpty(dto.ExpirationDate))
            {
                medicalReceipt.ExpirationDate = ParseToDateTime(dto.ExpirationDate);
            }

            await repository.SaveChangesAsync();

            return new UpdateMedicalReceiptResult(
                new UpdateMedicalReceiptResultDto()
            {
                Advice = medicalReceipt.Advice,
                AiAdvice = medicalReceipt.AiAdvice,
                AiDiagnosis = medicalReceipt.AiDiagnosis,
                CreatedAt = medicalReceipt.CreatedAt,
                DeletedOn = medicalReceipt.DeletedOn,
                MedicalReceiptId = medicalReceipt.MedicalReceiptId,
                Diagnosis = medicalReceipt.Diagnosis,
                DoctorId = medicalReceipt.DoctorId,
                PatientId = medicalReceipt.PatientId,
                ExpirationDate = medicalReceipt.ExpirationDate,
                IsDeleted = medicalReceipt.IsDeleted,
                IssueDate = medicalReceipt.IssueDate,
                MedicalReceiptsMedicines = medicalReceipt.MedicalReceiptsMedicines.Select(rm => new UpdateMedicalReceiptMedicineDto
                {
                    MedicineId = rm.MedicineId,
                    Quantity = rm.Quantity,
                    DurationDays = rm.DurationDays,
                    DosageInstructions = rm.DosageInstructions
                }).ToList(),
                UpdatedAt = medicalReceipt.UpdatedAt
            });
        }
    }

}
