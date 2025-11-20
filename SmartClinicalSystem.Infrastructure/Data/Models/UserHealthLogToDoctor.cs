using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClinicalSystem.Infrastructure.Data.Models
{
    public class UserHealthLogToDoctor
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [ForeignKey(nameof(UserHealthLogId))]
        public string UserHealthLogId { get; set; } = null!;
        public UserHealthLog? UserHealthLog { get; set; }

        [Required]
        [ForeignKey(nameof(DoctorId))]
        public string DoctorId { get; set; } = null!;
        public ApplicationUser? Doctor { get; set; }

        public bool IsViewedByDoctor { get; set; } = false;
    }
}
