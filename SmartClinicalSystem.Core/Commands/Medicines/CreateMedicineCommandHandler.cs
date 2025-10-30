using BuildingBlock.BuildingBlocks.CQRS;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.DTOs.Medicine;
using SmartClinicalSystem.Core.Exceptions;
using SmartClinicalSystem.Infrastructure.Common;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Commands.Medicines
{
    public record CreateMedicineCommand(CreateMedicineDTO CreateMedicineDto) : ICommand<CreateMedicineResult>;
    public record CreateMedicineResult(string Id);

    public class CreateMedicineCommandValidator : AbstractValidator<CreateMedicineCommand>
    {
        private const int MINIMUM_PRICE = 0;
        private const int MINIMUM_QUANTITY = -1;
        public CreateMedicineCommandValidator()
        {
            RuleFor(RuleFor => RuleFor.CreateMedicineDto.GenericName)
                .NotEmpty().WithMessage("Generic name is required.");

            RuleFor(RuleFor => RuleFor.CreateMedicineDto.StockQuantity)
                .NotEmpty().WithMessage("Stock quantity is required")
                .GreaterThan(MINIMUM_QUANTITY).WithMessage($"Quantity must be greater than {MINIMUM_QUANTITY}");

            RuleFor(RuleFor => RuleFor.CreateMedicineDto.Strength)
                .NotEmpty().WithMessage("Strength is required.");

            RuleFor(RuleFor => RuleFor.CreateMedicineDto.Category)
                .NotEmpty().WithMessage("Category is required.");

            RuleFor(RuleFor => RuleFor.CreateMedicineDto.DosageForm)
                .NotEmpty().WithMessage("Dosage form is required.");

            RuleFor(RuleFor => RuleFor.CreateMedicineDto.Manufacturer)
                .NotEmpty().WithMessage("Manufacturer is required.");

            RuleFor(RuleFor => RuleFor.CreateMedicineDto.Price)
                .NotEmpty().WithMessage("Price is required.")
                .GreaterThan(MINIMUM_PRICE).WithMessage($"Price must be greater than {MINIMUM_PRICE}");
        }
    }
    public class CreateMedicineCommandHandler(IRepository repository) : ICommandHandler<CreateMedicineCommand, CreateMedicineResult>
    {
        public async Task<CreateMedicineResult> Handle(CreateMedicineCommand request, CancellationToken cancellationToken)
        {
            if (await repository.AllReadOnly<Medicine>()
                .AnyAsync(m => m.GenericName == request.CreateMedicineDto.GenericName, cancellationToken))
            {
                throw new MedicineAlreadyExistsException();
            }

            var medicine = new Medicine()
            {
                GenericName = request.CreateMedicineDto.GenericName,
                StockQuantity = request.CreateMedicineDto.StockQuantity,
                Strength = request.CreateMedicineDto.Strength,
                Category = request.CreateMedicineDto.GetMedicineCategory(),
                DosageForm = request.CreateMedicineDto.DosageForm,
                Manufacturer = request.CreateMedicineDto.Manufacturer,
                Price = request.CreateMedicineDto.Price,
                SideEffects = request.CreateMedicineDto.SideEffects,
                Contraindications = request.CreateMedicineDto.Contraindications,
                Indications = request.CreateMedicineDto.Indications,
                Description = request.CreateMedicineDto.Description,
                Precautions = request.CreateMedicineDto.Precautions,
            };

            await repository.AddAsync(medicine);
            await repository.SaveChangesAsync();

            return new CreateMedicineResult(medicine.MedicineId);
        }
    }
}
