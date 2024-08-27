

using Microsoft.AspNetCore.Identity;
using testing.Identity.Enums;

namespace testing.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task GenerateDefaultApplicationRoles(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(nameof(Roles.Admin)));
            await roleManager.CreateAsync(new IdentityRole(nameof(Roles.Developer)));
            await roleManager.CreateAsync(new IdentityRole(nameof(Roles.Teacher)));
            await roleManager.CreateAsync(new IdentityRole(nameof(Roles.Client)));
        }
    }
}
