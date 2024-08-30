
using testing.Domain.Model;

namespace testing.Domain.Repositories.Identity
{
    public interface IAccountRepository<TUser> where TUser : class
    {
        Task<AuthenticationResponce> AuthenticateAsync(AuthenticationRequest authenticationRequest);
        Task<RegisterResponce> RegisterAsync(string Role, TUser userToBeRegisterd);

    }
}
