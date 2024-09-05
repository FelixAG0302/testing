using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using testing.Application.Contracts.Identity;
using testing.Application.Core;
using testing.Application.Models.Users;
using testing.Application.Utils.SessionHandler;
using testing.Domain.Model;
using testing.Domain.Repositories.Identity;
using testing.Domain.Settings;

namespace testing.Application.Services.Identity
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ISession _session;

        private readonly SessionKeys _sessionKeys;


        public AccountService(IAccountRepository accountRepository, ISession session, IOptions<SessionKeys> sessionskeys)
        {
            _accountRepository = accountRepository;
            _session = session;
            _sessionKeys = sessionskeys.Value;
        }

        public async Task<Result> AuthenticateUserAsync(string usernameOrEmail, string password)
        {
            Result result = new();
            try
            {
                if (usernameOrEmail == null && password == null)
                {
                    result.IsSuccess = false;
                    result.Message = "The inputs cant be empty";
                    return result;
                }
                AuthenticationResponce operationSuccess = await _accountRepository.AuthenticateAsync(new Domain.Model.AuthenticationRequest { UserNameOrEmail = usernameOrEmail, Password = password});

                if (operationSuccess.HasError)
                {
                    result.IsSuccess = false;
                    result.Message = operationSuccess.ErrorMessage;
                    return result;
                }
                _session.Set<AuthenticationResponce>( operationSuccess, _sessionKeys.UserKey);

                result.Message = "User was Log successfully";
                return result;
            }
            catch
            {
                result.IsSuccess = false;
                result.Message = "Critical error login in the user ";
                return result;
            }
        }

        public Task<Result> RegisterAsync(SaveUserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
