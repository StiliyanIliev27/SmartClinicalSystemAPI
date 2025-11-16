namespace SmartClinicalSystem.Core.DTOs.UserHealthLog
{
    public abstract class InputUserHealthLogDto
    {
        public string Symptoms { get; set; } = null!;
        public int PainLevel { get; set; } // 1–10 scale
        public string? SideEffects { get; set; }
        public string? Mood { get; set; }
        public double? Temperature { get; set; }
        public string? Notes { get; set; }
    }

    public class CreateUserHealthLogDto : InputUserHealthLogDto
    {
        public string UserId { get; set; } = null!;
    }

    public class UpdateUserHealthLogDto : InputUserHealthLogDto
    {
        public string Id { get; set; } = null!;
    }
}
