using Microsoft.AspNetCore.Identity;

namespace ITCenterBack.Constants
{
    public class AccountRoles
    {
        public const string Administrator = "Administrator";

        public static List<IdentityRole<long>> Roles { get; } = new()
        {
            new IdentityRole<long>(AccountRoles.Administrator) { Id = 1, NormalizedName = AccountRoles.Administrator.Normalize() }
        };
    }
}
