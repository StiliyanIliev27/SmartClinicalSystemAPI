using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SmartClinicalSystem.Infrastructure.Data.Models
{
    public class AiSummaryCheckerConsultation : AiConsultation
    {
        [Required]
        [Comment("The period (in days) for which the summary is to be checked")]
        public int InputPeriod { get; set; }
    
    }
}
