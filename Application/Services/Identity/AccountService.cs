using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using testing.Application.Contracts.Identity;
using testing.Application.Contracts.Persistance;
using testing.Application.Core;
using testing.Application.Extensions;
using testing.Application.Models.UserDegree;
using testing.Application.Models.Users;
using testing.Application.Utils.Enums;
using testing.Application.Utils.SessionHandler;
using testing.Domain.Model;
using testing.Domain.Repositories.Identity;
using testing.Domain.Repositories.Persistance;
using testing.Domain.Settings;
using testing.Identity.Enums;

namespace testing.Application.Services.Identity
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly ISession _session;
        private readonly IUserDegreeService _userDegreeService;

        private readonly SessionKeys _sessionKeys;


        public AccountService(IAccountRepository accountRepository,IMapper mapper, IServiceProvider serviceProvider, ISession session, IOptions<SessionKeys> sessionskeys)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _session = session;
            _sessionKeys = sessionskeys.Value;
            _userDegreeService = serviceProvider.GetRequiredService<IUserDegreeService>();
        }

        public async Task<Result> AuthenticateUserAsync(string usernameOrEmail, string password)
        {
            try
            {
                if (usernameOrEmail == null && password == null) 
                    return ErrorTypes.Validation.Because("The inputs cant be empty");
            
                AuthenticationResponce operationSuccess = await _accountRepository.AuthenticateAsync(new Domain.Model.AuthenticationRequest { UserNameOrEmail = usernameOrEmail, Password = password});

                if (operationSuccess.HasError) 
                    return ErrorTypes.OperationError.Because(operationSuccess.ErrorMessage);

                Result<UserDegreeModel> usersDegree = await _userDegreeService.GetByUserId(operationSuccess.Id);

                if (usersDegree.Data.DegreeId <= 0 && operationSuccess.Roles.Any(r => r == nameof(Roles.Client))) 
                    return ErrorTypes.OperationError.Because(usersDegree.Message);

                operationSuccess.DegreeId = usersDegree.Data.DegreeId;

                _session.Set<AuthenticationResponce>( operationSuccess, _sessionKeys.UserKey);

                return new("User was Log in successfully");
            }
            catch
            {
                return ErrorTypes.Exceptions.Because("Critical error login in the user");
            }
        }

        public async Task<Result> RegisterAsync(SaveUserModel user)
        {
            try
            {
                if (user == null)
                    return ErrorTypes.Validation.Because("The user to be registerd cant be null");

                RegisterRequest request = _mapper.Map<RegisterRequest>(user);

                RegisterResponce operationResponce = await _accountRepository.RegisterAsync(user.Role, request);

                return operationResponce.HasError ? ErrorTypes.OperationError.Because(operationResponce.ErrorMessage) 
                    : new("User register was succesfull");
            }
            catch
            {
                return ErrorTypes.Exceptions.Because("Critical error while registering the user");
            }
        }

        public async Task<Result> SignOutAsync()
        {
            try
            {
                await _accountRepository.LogOutAsync();

                return new("Success in the sign out");
            }
            catch
            {
                return ErrorTypes.Exceptions.Because("Critical error signing out the current user's");
            }
        }
    }
}
