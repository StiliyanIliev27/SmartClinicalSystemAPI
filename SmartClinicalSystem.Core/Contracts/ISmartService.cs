using SmartClinicalSystem.Core.DTOs.AI;
using SmartClinicalSystem.Core.Queries.AI;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Contracts
{
    public interface ISmartService
    {
        Task<DiagnoseResultDto?> GetDiagnosisAsync(string symptoms);
        Task<DiagnosisForMedicalReceiptDto> GetDiagnosisForMedicalReceiptAsync(MedicalReceipt medicalReceipt);
        Task<MedicineComparisonDto> GenerateComparisonReport(string firstMedicineId, string secondMedicineId, string diagnosis);
        Task<string> SummarizeMedicalDataAsync(IEnumerable<MedicalReceipt> medicalReceipts, IEnumerable<UserHealthLog> healthLogs);
    }
}
