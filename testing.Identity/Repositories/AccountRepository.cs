using Microsoft.AspNetCore.Identity;
using testing.Domain.Model;
using testing.Domain.Repositories.Identity;
using testing.Identity.Entities;

namespace testing.Identity.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RegistrationHandler _registrationHandler;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RegistrationHandler registrationHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _registrationHandler = registrationHandler;
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

            if (!userToBeAuthenticated.EmailConfirmed)
            {
                responce.HasError = true;
                responce.ErrorMessage = "Your account is unactivated, wait till an admin activates it";
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

        public async Task LogOutAsync()
        {
             await _signInManager.SignOutAsync();
        }

        public async Task<RegisterResponce> RegisterAsync(string Role, RegisterRequest userToBeRegisterd)
        {
            RegisterResponce responce = new();
            ApplicationUser user = await _userManager.FindByEmailAsync(userToBeRegisterd.Email);
            
            //Validations
            if (user is not null)
            {
                responce.HasError = true;
                responce.ErrorMessage = $"There is a email with the credentials: {userToBeRegisterd.Email}";
                return responce;
            }
            user = await _userManager.FindByNameAsync(userToBeRegisterd.UserName);

            if (user is not null)
            {
                responce.HasError = true;
                responce.ErrorMessage = $"There is a user with the user name: {userToBeRegisterd.UserName}";
                return responce;
            }

            user = new()
            {
                FirstName = userToBeRegisterd.FirstName,
                LastName = userToBeRegisterd.LastName,
                Email = userToBeRegisterd.Email,
                Cedula = userToBeRegisterd.Cedula,
                BirthDay = userToBeRegisterd.BirthDay,
                UserName = userToBeRegisterd.UserName,
                PhoneNumber = userToBeRegisterd.PhoneNumber,
            };
            
            responce = await _registrationHandler.Register(Role, user, userToBeRegisterd.Password);

            //Validations 
            return responce;
        }
    }
}
