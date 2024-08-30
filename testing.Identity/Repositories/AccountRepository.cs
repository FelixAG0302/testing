using Azure;
using Microsoft.AspNetCore.Identity;
using testing.Domain.Model;
using testing.Domain.Repositories.Identity;
using testing.Identity.Entities;

namespace testing.Identity.Repositories
{
    public class AccountRepository : IAccountRepository<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<AuthenticationResponce> AuthenticateAsync(AuthenticationRequest request)
        {
            AuthenticationResponce responce = new();

            ApplicationUser userToBeAuthenticated = await _userManager.FindByEmailAsync(request.UserNameOrEmail) ?? await _userManager.FindByNameAsync(request.UserNameOrEmail);

            if (userToBeAuthenticated == null)
            {
                responce.HasError = true;
                responce.ErrorMessage = "Incorrected email or user name. Please check if you tiped correctly";
                return responce;
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(userToBeAuthenticated, request.Password, false, false);

            if (!result.Succeeded) {
                responce.HasError = true;
                responce.ErrorMessage = "The password is incorrect. Please check the password inserted";
                return responce;
            }

            responce.Id = userToBeAuthenticated.Id;
            responce.UserName = userToBeAuthenticated.UserName;
            responce.Email = userToBeAuthenticated.Email;           
            responce.IsActive = userToBeAuthenticated.EmailConfirmed;
            IList<string> Roles = await _userManager.GetRolesAsync(userToBeAuthenticated);
            responce.Roles = Roles.ToList();

            return responce;
        }

        public Task<RegisterResponce> RegisterAsync(string Role, ApplicationUser userToBeRegisterd)
        {
            throw new NotImplementedException();
        }
    }
}
