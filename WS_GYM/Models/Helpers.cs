using System.Security.Claims;

namespace WS_GYM.Models
{
    public static class Helpers
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
