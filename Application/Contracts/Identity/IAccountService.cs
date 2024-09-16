

using testing.Application.Core;
using testing.Application.Models.Users;

namespace testing.Application.Contracts.Identity
{
   public interface IAccountService
    {
        Task<Result> AuthenticateUserAsync(string usernameOrEmail, string password);
        Task<Result> RegisterAsync(SaveUserModel user);
        Task<Result> SignOutAsync();

    }
}
