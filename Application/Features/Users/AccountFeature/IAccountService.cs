using testing.Application.Core;
using testing.Application.Features.Users.AccountFeature.Model;

namespace testing.Application.Features.Users.AccountFeature
{
    public interface IAccountService
    {
        Task<Result> AuthenticateUserAsync(string usernameOrEmail, string password);
        Task<Result> RegisterAsync(SaveUserModel user);
        Task<Result> SignOutAsync();

    }
}
