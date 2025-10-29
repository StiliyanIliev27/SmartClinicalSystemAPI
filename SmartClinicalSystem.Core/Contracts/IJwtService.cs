using SmartClinicalSystem.Infrastructure.Data.Models;
using System.Security.Claims;

namespace SmartClinicalSystem.Core.Contracts
{
    public interface IJwtService
    {
        string GenerateAccessToken(ApplicationUser user, IList<string> roles);
        RefreshToken GenerateRefreshToken(ApplicationUser user);
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    }
}
