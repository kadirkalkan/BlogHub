using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogHub.Extensions
{
    public static class UserClaimExtensions
    {
        public static string GetID(this ClaimsPrincipal principal) {
            return principal.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public static bool IsThisUserLoggedOne(this ClaimsPrincipal principal, string id) {
            return principal.GetID().Equals(id);
        }
    }
}
