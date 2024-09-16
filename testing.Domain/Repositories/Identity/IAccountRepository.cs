
using testing.Domain.Model;

namespace testing.Domain.Repositories.Identity
{
    public interface IAccountRepository
    {
        Task<AuthenticationResponce> AuthenticateAsync(AuthenticationRequest authenticationRequest);
        Task<RegisterResponce> RegisterAsync(string Role, RegisterRequest userToBeRegisterd);
        Task LogOutAsync();

    }
}
