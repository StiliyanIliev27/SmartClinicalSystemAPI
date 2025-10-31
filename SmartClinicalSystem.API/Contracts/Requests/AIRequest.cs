namespace SmartClinicalSystem.API.Contracts.Requests
{
    public static class AIRequest
    {
        public record DiagnoseRequest(string Symptoms);
    }
}
