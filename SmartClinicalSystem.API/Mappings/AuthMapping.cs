using Mapster;
using Microsoft.AspNetCore.Identity.Data;
using SmartClinicalSystem.Core.Commands.Auth;

namespace SmartClinicalSystem.API.Mappings
{
    public class AuthMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, CreateUserCommand>();
            config.NewConfig<LoginRequest, AuthenticateUserCommand>();
        }
    }
}
