namespace SmartClinicalSystem.Core.Configs
{
    public class OpenAiOptions
    {
        public string ApiKey { get; set; } = null!;
        public string Model { get; set; } = "gpt-4o-mini";
    }
}
