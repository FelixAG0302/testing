using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Identity.Entities;
using testing.Identity.Enums;

namespace testing.Identity.Seeds
{
    public static class AddDefaultClientUser
    {
        public static async Task GenerateDefaultCliente(UserManager<ApplicationUser> userManager)
        {
            ApplicationUser DefaultClient = new()
            {
                FirstName = "DefaultFirstName",
                LastName = "DefaultLastName",
                PhoneNumber = "1234567890",
                Cedula = "40245785047",
                Email = "DefaultEmailClient@gmail.com",
                UserName = "DefaultClient",
            };

            if (!await userManager.Users.AnyAsync(u => u.Id == DefaultClient.Id))
            {
                ApplicationUser userWithSameCredentials = await userManager.FindByEmailAsync(DefaultClient.Email)
                    ?? await userManager.FindByNameAsync(DefaultClient.UserName);
                if (userManager == null)
                {
                    await userManager.CreateAsync(DefaultClient, "Test123");
                    await userManager.AddToRoleAsync(DefaultClient, nameof(Roles.Client));
                }
            }
        }
    }
}
