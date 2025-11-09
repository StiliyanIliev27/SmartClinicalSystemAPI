using SmartClinicalSystem.Core.DTOs.Doctor;
using SmartClinicalSystem.Core.Queries.AI;
using SmartClinicalSystem.Infrastructure.Data.Models;

namespace SmartClinicalSystem.Core.Contracts
{
    public interface ISmartService
    {
        Task<DiagnoseResultDto?> GetDiagnosisAsync(string symptoms);
        Task<DiagnosisForMedicalReceiptDto> GetDiagnosisForMedicalReceiptAsync(MedicalReceipt medicalReceipt);
    }
}
