using System.ComponentModel.DataAnnotations;

namespace SmartClinicalSystem.Infrastructure.Data.Models
{
    public class AiDiagnosisConsultation : AiConsultation
    {
        [Required]
        public string Symptoms { get; set; } = null!;
    }
}
