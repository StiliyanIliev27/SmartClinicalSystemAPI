using BuildingBlock.BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.DTOs.Doctor;
using SmartClinicalSystem.Infrastructure.Data.Enums;
using SmartClinicalSystem.Infrastructure.Data.Models;
using static SmartClinicalSystem.Core.Helpers.DateFormatHelper;

namespace SmartClinicalSystem.Core.Commands.Doctors
{
    public record CreateMedicalReceiptCommand(CreateMedicalReceiptDto MedicalReceiptCreateDto) 
        : ICommand<CreateMedicalReceiptResult>;
    public record CreateMedicalReceiptResult(string Id);
    public class CreateMedicalReceiptCommandHandler(IRepository repository, 
        ISmartService smartService, INotificationService notificationService)
        : ICommandHandler<CreateMedicalReceiptCommand, CreateMedicalReceiptResult>
    {
        public async Task<CreateMedicalReceiptResult> Handle(CreateMedicalReceiptCommand command, CancellationToken cancellationToken)
        {
            if(!await AllMedicinesExistAsync(command.MedicalReceiptCreateDto.Medicines.Select(m => m.MedicineId)))
            {
                throw new Exception("One or more medicines do not exist.");
            }

            var medicalReceipt = new MedicalReceipt()
            {
                Advice = command.MedicalReceiptCreateDto.Advice,
                Diagnosis = command.MedicalReceiptCreateDto.Diagnosis,
                PatientId = command.MedicalReceiptCreateDto.PatientId,
                DoctorId = command.MedicalReceiptCreateDto.DoctorId
            };

            if (!string.IsNullOrEmpty(command.MedicalReceiptCreateDto.ExpirationDate))
            {
                medicalReceipt.ExpirationDate = ParseToDateTime(command.MedicalReceiptCreateDto.ExpirationDate);
            }

            ICollection<MedicalReceiptMedicine> medicalReceiptMedicines = new HashSet<MedicalReceiptMedicine>();
            foreach (var medicine in command.MedicalReceiptCreateDto.Medicines)
            {
                var medicalReceiptMedicine = new MedicalReceiptMedicine()
                {
                    MedicalReceiptId = medicalReceipt.MedicalReceiptId,
                    MedicineId = medicine.MedicineId,
                    DosageInstructions = medicine.DosageInstructions,
                    DurationDays = medicine.DurationDays,
                    Quantity = medicine.Quantity
                };

                await repository.AddAsync(medicalReceiptMedicine);
                medicalReceiptMedicines.Add(medicalReceiptMedicine);
            }

            medicalReceipt.MedicalReceiptsMedicines = medicalReceiptMedicines;

            if (command.MedicalReceiptCreateDto.UseAiDiagnosis)
            {
                var aiDiagnosis = await smartService.GetDiagnosisForMedicalReceiptAsync(medicalReceipt);

                if (aiDiagnosis != null)
                {
                    medicalReceipt.AiAdvice = aiDiagnosis.AiAdvice;
                    medicalReceipt.AiDiagnosis = aiDiagnosis.AiDiagnosis;
                }
            }

            await repository.AddAsync(medicalReceipt);
            await repository.SaveChangesAsync();

            await notificationService.SendNotificationAsync(command.MedicalReceiptCreateDto.PatientId,
                "A new medical receipt has been created for you.", NotificationType.MedicalReceipt);

            return new CreateMedicalReceiptResult(medicalReceipt.MedicalReceiptId);
        }

        private async Task<bool> AllMedicinesExistAsync(IEnumerable<string> medicineIds)
        {
            var validIds = medicineIds.Distinct().ToList();

            var count = await repository.AllReadOnly<Medicine>()
                .Where(m => !m.IsDeleted && validIds.Contains(m.MedicineId))
                .CountAsync();

            return count == validIds.Count;
        }
    }
}
