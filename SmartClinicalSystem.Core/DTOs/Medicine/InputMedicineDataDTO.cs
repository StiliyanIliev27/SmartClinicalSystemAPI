using SmartClinicalSystem.Infrastructure.Data.Enums;

namespace SmartClinicalSystem.Core.DTOs.Medicine
{
    public abstract class InputMedicineDataDTO
    {
        public string GenericName { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string DosageForm { get; set; } = null!;
        public string Strength { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public MedicineCategory GetMedicineCategory()
        {
            return Enum.TryParse(typeof(MedicineCategory), Category, true, out var category) 
                ? (MedicineCategory)category!
                : throw new ArgumentException($"Invalid medicine category: {Category}");
        }
    }

    public class CreateMedicineDTO : InputMedicineDataDTO
    {
        
    }

    public class UpdateMedicineDTO : InputMedicineDataDTO
    {
        public string MedicineId { get; set; } = null!;
    }
}
