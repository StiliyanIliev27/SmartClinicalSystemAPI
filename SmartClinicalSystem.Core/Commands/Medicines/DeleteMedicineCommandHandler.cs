using BuildingBlock.BuildingBlocks.CQRS;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.Exceptions.NotFound;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Commands.Medicines
{
    public record DeleteMedicineCommand(string Id) : ICommand<DeleteMedicineResult>;
    public record class DeleteMedicineResult(bool Success, string Message);
    public class DeleteMedicineCommandHandler(IRepository repository) : ICommandHandler<DeleteMedicineCommand, DeleteMedicineResult>
    {
        public async Task<DeleteMedicineResult> Handle(DeleteMedicineCommand request, CancellationToken cancellationToken)
        {
            var medicine = await repository.GetByIdAsync<Medicine>(request.Id)
                ?? throw new MedicineNotFoundException(request.Id);

            if(medicine.IsDeleted)
            {
                return new DeleteMedicineResult(false, $"Medicine ({medicine.MedicineId}) is already deleted.");
            }

            medicine.IsDeleted = true;
            medicine.DeletedOn = DateTime.Now;

            await repository.SaveChangesAsync();

            return new DeleteMedicineResult(true, $"Medicine ({medicine.MedicineId}) deleted successfully.");
        }
    }
}
