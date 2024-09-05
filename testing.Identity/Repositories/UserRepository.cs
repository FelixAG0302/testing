

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using testing.Domain.Repositories.Identity;
using testing.Identity.Entities;

namespace testing.Identity.Repositories
{
    public class UserRepository : IUserRepository<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<List<ApplicationUser>> GetAllAsync(string role)
        {
            return await _userManager.GetUsersInRoleAsync(role) as List<ApplicationUser>;
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {

            return await _userManager.FindByIdAsync(id);
        }

        public async Task<bool> HandleUserStateAsync(string id)
        {
            ApplicationUser userToBeHandle = await _userManager.FindByIdAsync(id);

            if (userToBeHandle == null) return false;

            IdentityResult result;

            if (!userToBeHandle.EmailConfirmed)
            {
                string token = await _userManager.GenerateEmailConfirmationTokenAsync(userToBeHandle);
                result = await _userManager.ConfirmEmailAsync(userToBeHandle, token);

                return result.Succeeded;
            }

            userToBeHandle.EmailConfirmed = false;
            result = await _userManager.UpdateAsync(userToBeHandle);
            return result.Succeeded;
        }

        public async Task<bool> UpdateAsync(ApplicationUser entity, string newPassword)
        {
            if(await _userManager.Users.Where(u => (u.UserName == entity.UserName || u.Email == entity.Email) && u.Id != entity.Id).AnyAsync()) return false;

            ApplicationUser userToBeUpdate = await _userManager.FindByIdAsync(entity.Id);

            if (userToBeUpdate == null) return false;

            userToBeUpdate.FirstName = entity.FirstName;
            userToBeUpdate.LastName = entity.LastName;
            userToBeUpdate.UserName = entity.UserName;
            userToBeUpdate.PhoneNumber = entity.PhoneNumber;
            userToBeUpdate.Cedula = entity.Cedula;
            userToBeUpdate.Email = entity.Email;

            IdentityResult result = await _userManager.UpdateAsync(userToBeUpdate);

            if (!result.Succeeded || newPassword == null) return result.Succeeded;

            string token = await _userManager.GeneratePasswordResetTokenAsync(userToBeUpdate);

            result = await _userManager.ResetPasswordAsync(userToBeUpdate, token, newPassword);

            return result.Succeeded;
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            ApplicationUser userToBeDeleted = await _userManager.FindByIdAsync(Id);

            if (userToBeDeleted == null) return false;

            IdentityResult result = await _userManager.DeleteAsync(userToBeDeleted);

            return result.Succeeded;
        }
    }
}
