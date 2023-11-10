using System.Security.Claims;

namespace Bookstore.API.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
       public static string GetUserName(this ClaimsPrincipal user)
        {
            return user.FindFirst("UserName").Value;
        }
        public static int GetUserId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst("UserId").Value);
        } 
    }
}