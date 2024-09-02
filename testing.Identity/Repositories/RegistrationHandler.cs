

using Microsoft.AspNetCore.Identity;
using testing.Domain.Model;
using testing.Identity.Entities;
using testing.Identity.Enums;

namespace testing.Identity.Repositories
{
    public class RegistrationHandler
    {
        private readonly Dictionary<string, Func<string, ApplicationUser, string, Task<RegisterResponce>>> RegisterHandler;
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistrationHandler(UserManager<ApplicationUser> userManager)
        {
            RegisterHandler = new()
            {
                {nameof(Roles.Client), RegisterClientAsync },
                {nameof(Roles.Teacher), RegisterTeacherAsync },
                {nameof(Roles.Admin), RegisterAdminAsync },
                {nameof(Roles.Developer), RegisterDeveloperAsync }

            };
            _userManager = userManager;
        }
        public async Task<RegisterResponce> Register(string role, ApplicationUser user, string password)
        {
            return await RegisterHandler[role](role, user, password);
        }

        private async Task<RegisterResponce> RegisterClientAsync(string role, ApplicationUser applicationUser, string password)
        {
            RegisterResponce responce = new();
            applicationUser.EmailConfirmed = false;

            IdentityResult result = await _userManager.CreateAsync(applicationUser, password);

            if (!result.Succeeded)
            {
                responce.HasError = true;
                responce.ErrorMessage = result.Errors.First().Description;
                return responce;
            }

            result = await _userManager.AddToRoleAsync(applicationUser, nameof(Roles.Client));
            if (!result.Succeeded)
            {
                responce.HasError = true;
                responce.ErrorMessage = result.Errors.First().Description;
                return responce;
            }

            return responce;
        }
        private async Task<RegisterResponce> RegisterTeacherAsync(string role, ApplicationUser applicationUser, string password)
        {
            RegisterResponce responce = new();
            applicationUser.EmailConfirmed = false;

            IdentityResult result = await _userManager.CreateAsync(applicationUser, password);

            if (!result.Succeeded)
            {
                responce.HasError = true;
                responce.ErrorMessage = result.Errors.First().Description;
                return responce;
            }

            result = await _userManager.AddToRoleAsync(applicationUser, nameof(Roles.Client));
            if (!result.Succeeded)
            {
                responce.HasError = true;
                responce.ErrorMessage = result.Errors.First().Description;
                return responce;
            }

            return responce;
        }
        private async Task<RegisterResponce> RegisterDeveloperAsync(string role, ApplicationUser applicationUser, string password)
        {
            RegisterResponce responce = new();
            applicationUser.EmailConfirmed = false;

            IdentityResult result = await _userManager.CreateAsync(applicationUser, password);
            if (!result.Succeeded)
            {
                responce.HasError = true;
                responce.ErrorMessage = result.Errors.First().Description;
                return responce;
            }

            result = await _userManager.AddToRoleAsync(applicationUser, nameof(Roles.Developer));
            if (!result.Succeeded)
            {
                responce.HasError = true;
                responce.ErrorMessage = result.Errors.First().Description;
                return responce;
            }

            return responce;
        }
        private async Task<RegisterResponce> RegisterAdminAsync(string role, ApplicationUser applicationUser, string password)
        {
            RegisterResponce responce = new();
            applicationUser.EmailConfirmed = true;

            IdentityResult result = await _userManager.CreateAsync(applicationUser, password);
            if (!result.Succeeded)
            {
                responce.HasError = true;
                responce.ErrorMessage = result.Errors.First().Description;
                return responce;
            }

            result = await _userManager.AddToRoleAsync(applicationUser, nameof(Roles.Admin));
            if (!result.Succeeded)
            {
                responce.HasError = true;
                responce.ErrorMessage = result.Errors.First().Description;
                return responce;
            }

            return responce;
        }

    }
}
