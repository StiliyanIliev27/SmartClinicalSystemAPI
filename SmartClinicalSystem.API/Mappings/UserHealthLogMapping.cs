using Mapster;
using static SmartClinicalSystem.API.Contracts.Requests.UserHealthLogRequest;
using SmartClinicalSystem.Core.Commands.HealthLogs;


namespace SmartClinicalSystem.API.Mappings
{
    public class UserHealthLogMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateUserHealthLogRequest, CreateUserHealthCommand>()
                .Map(dest => dest.CreateUserHealthLogDto, src => src.createUserHealthLogDto);

            config.NewConfig<UpdateUserHealthLogRequest, UpdateUserHealthLogCommand>()
                .Map(dest => dest.UpdateUserHealthLogDto, src => src.updateUserHealthLogDto);
        }
    }
}
