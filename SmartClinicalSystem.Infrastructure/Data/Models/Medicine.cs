using SmartClinicalSystem.Infrastructure.Data.Enums;
using SmartClinicalSystem.Infrastructure.Data.Interfaces;

namespace SmartClinicalSystem.Infrastructure.Data.Models
{
    public class Medicine : IAuditableEntity, IDeletableEntity
    {
        public Medicine()
        {
            MedicineId = Guid.NewGuid().ToString();
        }

        public string MedicineId { get; set; }
        public string GenericName { get; set; } = null!;
        public MedicineCategory Category { get; set; }
        public string DosageForm { get; set; } = null!;
        public string Strength { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
