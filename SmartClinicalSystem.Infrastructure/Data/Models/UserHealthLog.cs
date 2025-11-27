using SmartClinicalSystem.Infrastructure.Data.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartClinicalSystem.Infrastructure.Data.Models
{
    public class UserHealthLog : IAuditableEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        public string? Symptoms { get; set; }
        public int? PainLevel { get; set; } // 1–10 scale
        public string? SideEffects { get; set; }
        public string? Mood { get; set; }
        public double? Temperature { get; set; }
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public UserHealthLogToDoctor? UserHealthLogToDoctor { get; set; }
    }

}
