using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClinicalSystem.Infrastructure.Data.Models
{
    public class PatientDoctor
    {
        [Required]
        [Key]
        public string PatientDoctorId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(PatientId))]
        public string PatientId { get; set; } = null!;
        public ApplicationUser? Patient { get; set; }

        [Required]
        [ForeignKey(nameof(DoctorId))]
        public string DoctorId { get; set; } = null!;
        public ApplicationUser? Doctor { get; set; }

        public DateTime RelationshipCreated { get; set; } = DateTime.Now;
    }
}
