namespace System.Security.Claims;

public static class ClaimsPrincipleExtension
{
    public static string GetUserId(this ClaimsPrincipal user)
    {
        return user.FindFirstValue(ClaimTypes.NameIdentifier)!;
    }
    public static bool IsAdmin(this ClaimsPrincipal user)
    {
        return user.IsInRole("Admin");
    }
    public static bool IsDoctor(this ClaimsPrincipal user)
    {
        return user.IsInRole("Doctor");
    }
}

