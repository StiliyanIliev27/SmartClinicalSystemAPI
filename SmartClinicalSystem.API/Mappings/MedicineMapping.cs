using Mapster;
using SmartClinicalSystem.Core.Commands.Medicines;
using static SmartClinicalSystem.API.Contracts.Requests.MedicineRequests;

namespace SmartClinicalSystem.API.Mappings
{
    public class MedicineMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateMedicineRequest, CreateMedicineCommand>()
                .Map(dest => dest.CreateMedicineDto, src => src.createMedicineDto);

            config.NewConfig<UpdateMedicineRequest, UpdateMedicineCommand>()
                .Map(dest => dest.UpdateMedicineDTO, src => src.updateMedicineDto);
        }
    }
}
