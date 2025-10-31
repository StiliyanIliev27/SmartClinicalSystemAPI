using SmartClinicalSystem.Core.Queries.AI;

namespace SmartClinicalSystem.Core.Contracts
{
    public interface ISmartService
    {
        Task<DiagnoseResultDto?> GetDiagnosisAsync(string symptoms);
    }
}
