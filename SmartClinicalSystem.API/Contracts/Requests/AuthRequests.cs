namespace SmartClinicalSystem.API.Contracts.Requests
{
    public static class AuthRequests
    {
        public record SignInRequest(string Username, string Password);
        public record SignUpRequest(string Username, string Email, string Password);
        public record RefreshTokenRequest(string AccessToken, string RefreshToken);
    }
}
