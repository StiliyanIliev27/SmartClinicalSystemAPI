using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClinicalSystem.Infrastructure.Data.Models
{
    public class AiCompareConsultation : AiConsultation
    {
        [Required]
        [ForeignKey(nameof(FirstMedicineId))]
        public string FirstMedicineId { get; set; } = null!;
        public Medicine? FirstMedicine { get; set; }

        [Required]
        [ForeignKey(nameof(SecondMedicineId))]
        public string SecondMedicineId { get; set; } = null!;
        public Medicine? SecondMedicine { get; set; }
    }
}
