using SmartClinicalSystem.Core.DTOs.Doctor;

namespace SmartClinicalSystem.API.Contracts.Requests
{
    public static class DoctorRequests
    {
        public record CreateMedicalReceiptRequest(CreateMedicalReceiptDto createMedicalReceiptDto);
    }
} 