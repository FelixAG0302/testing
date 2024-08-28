
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using testing.Identity.Entities;
using testing.Identity.Enums;

namespace testing.Identity.Seeds
{
    public static class AddDefaultAdminUser
    {
        public static async Task GenerateDefaultAdminUser(UserManager<ApplicationUser> userManager)
        {
            ApplicationUser DefaultAdmin = new()
            {
                FirstName = "DefaultFirstName",
                LastName = "DefaultLastName",
                PhoneNumber = "1234567890",
                Cedula = "40245785047",
                Email = "DefaultEmailAdmin@gmail.com",
                UserName = "DefaultAdmin",
            };

            if (!await userManager.Users.AnyAsync(u => u.Id == DefaultAdmin.Id))
            {
                ApplicationUser userWithSameCredentials = await userManager.FindByEmailAsync(DefaultAdmin.Email) 
                    ?? await userManager.FindByNameAsync(DefaultAdmin.UserName);

                if(userManager == null)
                {
                    await userManager.CreateAsync(DefaultAdmin, "123Test!");
                    await userManager.AddToRoleAsync(DefaultAdmin, nameof(Roles.Admin));
                }
            }
            
        }
    }
}
