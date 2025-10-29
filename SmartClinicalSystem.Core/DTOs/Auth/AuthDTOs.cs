namespace SmartClinicalSystem.Core.DTOs.Auth
{
    public static class AuthDTOs
    {
        public record AuthenticatedUserDto(
            string Id,
            string Username,
            string Email,
            IEnumerable<string> Roles
        );
    }
}
