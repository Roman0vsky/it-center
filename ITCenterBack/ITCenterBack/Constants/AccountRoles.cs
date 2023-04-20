using Microsoft.AspNetCore.Identity;

namespace ITCenterBack.Constants
{
    public class AccountRoles
    {
        public const string Administrator = "Administrator";

        public static List<IdentityRole<Guid>> Roles { get; } = new()
        {
            new IdentityRole<Guid>(AccountRoles.Administrator) { Id = Guid.NewGuid(), NormalizedName = AccountRoles.Administrator.Normalize() }
        };
    }
}
