using MapsterMapper;
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
        private readonly IMapper _mapper;
        private readonly ISession _session;

        private readonly SessionKeys _sessionKeys;


        public AccountService(IAccountRepository accountRepository,IMapper mapper, ISession session, IOptions<SessionKeys> sessionskeys)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _session = session;
            _sessionKeys = sessionskeys.Value;
        }

        public async Task<Result> AuthenticateUserAsync(string usernameOrEmail, string password)
        {
            try
            {
                if (usernameOrEmail == null && password == null) return new("The inputs cant be empty", false);
            
                AuthenticationResponce operationSuccess = await _accountRepository.AuthenticateAsync(new Domain.Model.AuthenticationRequest { UserNameOrEmail = usernameOrEmail, Password = password});

                if (operationSuccess.HasError) return new(operationSuccess.ErrorMessage, false);
             
                _session.Set<AuthenticationResponce>( operationSuccess, _sessionKeys.UserKey);

                return new("User was Log successfully");
            }
            catch
            {
                return new("Critical error login in the user", false);
            }
        }

        public async Task<Result> RegisterAsync(SaveUserModel user)
        {
            try
            {
                if (user == null) 
                    return new("The user to be registerd cant be null", false);

                RegisterRequest request = _mapper.Map<RegisterRequest>(user);

                RegisterResponce operationResponce = await _accountRepository.RegisterAsync(user.Role, request);

                return operationResponce.HasError ? new(operationResponce.ErrorMessage, false) 
                    : new("User register was succesfull");
            }
            catch
            {
                return new("Critical error while registering the user", false);
            }
        }


    }
}
