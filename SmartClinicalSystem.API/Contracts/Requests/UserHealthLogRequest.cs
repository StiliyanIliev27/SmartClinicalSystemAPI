using SmartClinicalSystem.Core.DTOs.UserHealthLog;

namespace SmartClinicalSystem.API.Contracts.Requests
{
    public class UserHealthLogRequest
    {
        public record CreateUserHealthLogRequest(CreateUserHealthLogDto createUserHealthLogDto);
        public record UpdateUserHealthLogRequest(UpdateUserHealthLogDto updateUserHealthLogDto);
    }
}
