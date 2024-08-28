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
    public static class AddDefaultTeacherUser
    {
        public static async Task GenerateDefaultTeacherUser(UserManager<ApplicationUser> userManager)
        {
            ApplicationUser DefaultTeacher = new()
            {
                FirstName = "DefaultFirstName",
                LastName = "DefaultLastName",
                PhoneNumber = "1234567890",
                Cedula = "40245785047",
                Email = "DefaultEmailTeacher@gmail.com",
                UserName = "DefaultTeacher",
            };

            if(!await userManager.Users.AnyAsync(u => u.Id == DefaultTeacher.Id))
            {
                ApplicationUser UserWithSameCredentials = await userManager.FindByEmailAsync(DefaultTeacher.Email)
                    ?? await userManager.FindByNameAsync(DefaultTeacher.UserName);
                if (userManager == null)
                {
                    await userManager.CreateAsync( DefaultTeacher,"Test123");
                    await userManager.AddToRoleAsync(DefaultTeacher, nameof(Roles.Teacher));
                }
            }

        }
    }
}
