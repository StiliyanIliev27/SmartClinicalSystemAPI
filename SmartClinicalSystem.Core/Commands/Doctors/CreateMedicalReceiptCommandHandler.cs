using BuildingBlock.BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.DTOs.Doctor;
using SmartClinicalSystem.Infrastructure.Data.Models;
using System.Globalization;

namespace SmartClinicalSystem.Core.Commands.Doctors
{
    public record CreateMedicalReceiptCommand(CreateMedicalReceiptDto MedicalReceiptCreateDto) 
        : ICommand<CreateMedicalReceiptResult>;
    public record CreateMedicalReceiptResult(string Id);
    public class CreateMedicalReceiptCommandHandler(IRepository repository, ISmartService smartService) : ICommandHandler<CreateMedicalReceiptCommand, CreateMedicalReceiptResult>
    {
        public async Task<CreateMedicalReceiptResult> Handle(CreateMedicalReceiptCommand command, CancellationToken cancellationToken)
        {
            if(!await AllMedicinesExistAsync(command.MedicalReceiptCreateDto.MedicineIds))
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
                var dateFormats = new[] { "dd-MM-yyyy", "dd/MM/yyyy", "yyyy-MM-dd" };

                if (DateTime.TryParseExact(
                        command.MedicalReceiptCreateDto.ExpirationDate,
                        dateFormats,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out var parsedDate))
                {
                    medicalReceipt.ExpirationDate = parsedDate;
                }
                else
                {
                    throw new FormatException(
                        $"Invalid date format: '{command.MedicalReceiptCreateDto.ExpirationDate}'. " +
                        "Use one of: dd-MM-yyyy, dd/MM/yyyy, yyyy-MM-dd.");
                }
            }

            ICollection<MedicalReceiptMedicine> medicalReceiptMedicines = new HashSet<MedicalReceiptMedicine>();
            foreach (string medicineId in command.MedicalReceiptCreateDto.MedicineIds)
            {
                var medicalReceiptMedicine = new MedicalReceiptMedicine()
                {
                    MedicalReceiptId = medicalReceipt.MedicalReceiptId,
                    MedicineId = medicineId,
                    DosageInstructions = command.MedicalReceiptCreateDto.DosageInstructions,
                    DurationDays = command.MedicalReceiptCreateDto.DurationDays,
                    Quantity = command.MedicalReceiptCreateDto.Quantity
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
