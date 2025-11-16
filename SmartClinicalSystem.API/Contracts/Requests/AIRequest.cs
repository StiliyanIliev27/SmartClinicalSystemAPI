namespace SmartClinicalSystem.API.Contracts.Requests
{
    public static class AIRequest
    {
        public record DiagnoseRequest(string Symptoms);
        public record class CompareRequest(string FirstMedicineId, string SecondMedicineId, string Diagnosis);
    }
}
