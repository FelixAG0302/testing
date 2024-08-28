﻿using Microsoft.AspNetCore.Identity;
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
    public static class AddDefaultDeveloperUser
    {
        public static async Task GenerateDefaultDeveloperUser(UserManager<ApplicationUser> userManager)
        {
            ApplicationUser DefaultDeveloper = new()
            {
                FirstName = "DefaultFirstName",
                LastName = "DefaultLastName",
                PhoneNumber = "1234567890",
                Cedula = "40245785047",
                Email = "DefaultEmailDeveloper@gmail.com",
                UserName = "DefaultDeveloper",
            };

            if (!await userManager.Users.AnyAsync(u => u.Id == DefaultDeveloper.Id))
            {
                ApplicationUser UserWithSameCredentials = await userManager.FindByEmailAsync(DefaultDeveloper.Email)
                ?? await userManager.FindByNameAsync(DefaultDeveloper.UserName);

                if(userManager == null)
                {
                    await userManager.CreateAsync(DefaultDeveloper, "Test123");
                    await userManager.AddToRoleAsync(DefaultDeveloper, nameof(Roles.Developer));
                }
            }
        }
    }
}
