using BuildingBlock.BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.DTOs.Medicine;
using SmartClinicalSystem.Core.Exceptions;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Commands.Medicines
{
    public record UpdateMedicineCommand(UpdateMedicineDTO UpdateMedicineDTO) : ICommand<UpdateMedicineResult>;
    public record UpdateMedicineResult(Medicine Result);
    public class UpdateMedicineCommandHandler(IRepository repository) : ICommandHandler<UpdateMedicineCommand, UpdateMedicineResult>
    {
        public async Task<UpdateMedicineResult> Handle(UpdateMedicineCommand request, CancellationToken cancellationToken)
        {
            var medicine = await repository.All<Medicine>()
                .FirstOrDefaultAsync(m => m.MedicineId == request.UpdateMedicineDTO.MedicineId, cancellationToken)
                ?? throw new MedicineNotFoundException(request.UpdateMedicineDTO.MedicineId);

            await UpdateMedicineAsync(medicine, request.UpdateMedicineDTO);
            await repository.SaveChangesAsync();

            return new UpdateMedicineResult(medicine);
        }

        private Task UpdateMedicineAsync(Medicine medicine, UpdateMedicineDTO updateMedicineDTO)
        {
            medicine.GenericName = updateMedicineDTO.GenericName;
            medicine.StockQuantity = updateMedicineDTO.StockQuantity;
            medicine.Strength = updateMedicineDTO.Strength;
            medicine.Category = updateMedicineDTO.GetMedicineCategory();
            medicine.DosageForm = updateMedicineDTO.DosageForm;
            medicine.Manufacturer = updateMedicineDTO.Manufacturer;
            medicine.Price = updateMedicineDTO.Price;
            medicine.Contraindications = updateMedicineDTO.Contraindications;
            medicine.Precautions = updateMedicineDTO.Precautions;
            medicine.Indications = updateMedicineDTO.Indications;
            medicine.Description = updateMedicineDTO.Description;
            medicine.SideEffects = updateMedicineDTO.SideEffects;
            medicine.UpdatedAt = DateTime.Now;

            return Task.CompletedTask;
        }
    }
}
