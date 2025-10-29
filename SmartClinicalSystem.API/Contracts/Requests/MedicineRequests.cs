using SmartClinicalSystem.Core.DTOs.Medicine;

namespace SmartClinicalSystem.API.Contracts.Requests
{
    public static class MedicineRequests
    {
        public record CreateMedicineRequest(CreateMedicineDTO createMedicineDto);
        public record UpdateMedicineRequest(UpdateMedicineDTO updateMedicineDto);
    }
}
