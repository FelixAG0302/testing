
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using testing.Application.Contracts.Identity;
using testing.Application.Core;
using testing.Application.Extensions;
using testing.Application.Models.Users;
using testing.Application.Utils.Enums;
using testing.Application.Utils.SessionHandler;
using testing.Domain.Model;
using testing.Domain.Repositories.Identity;
using testing.Domain.Settings;
using testing.Identity.Entities;

namespace testing.Application.Services.Identity
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<ApplicationUser> _userRepository;
        private readonly IMapper _mapper;
        private readonly AuthenticationResponce _currentUser;
        private readonly SessionKeys _sessionKeys;

        public UserService(IUserRepository<ApplicationUser> userRepository, IMapper mapper, ISession session, IOptions<SessionKeys> sessionKeys)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _sessionKeys = sessionKeys.Value;
            _currentUser = session.Get<AuthenticationResponce>(_sessionKeys.UserKey);
        }

        public async Task<Result<List<UserModel>>> GetAllAsync(string role)
        {
            try
            {
                if (role == null) 
                    return ErrorTypes.Validation.Because("Role of the users to get cant be null");

                List<ApplicationUser> usersGetted = await _userRepository.GetAllAsync(role);

                return  _mapper.Map<List<UserModel>>(usersGetted);
            }
            catch
            {
                return ErrorTypes.Exceptions.Because("Critical error getting the user's ");
            }
        }

        public async Task<Result<UserModel>> GetByIdAsync(string id)
        {
            try
            {
                if (id == default) 
                    return ErrorTypes.Validation.Because("id can not be empty");

                ApplicationUser userGettedById = await _userRepository.GetByIdAsync(id);

                return  _mapper.Map<UserModel>(userGettedById);
            }
            catch
            {
                return ErrorTypes.Exceptions.Because("Critical error while getting the requested user by id");
            }
        }

        public async Task<Result> HandleUserStateAsync(string id)
        {
            try
            {
                if (id == default) return ErrorTypes.Validation.Because("id can not be empty");

                bool isOperationASuccess = await _userRepository.HandleUserStateAsync(id);

                return !isOperationASuccess ? ErrorTypes.OperationError.Because("Error while trying to update the user state") : new("state update was a success");
            }
            catch
            {
                return ErrorTypes.Exceptions.Because("Critical error while changing the user state");
            }
        }

        public async Task<Result> UpdateAsync(SaveUserModel saveModel)
        {
            try
            {
                if (saveModel == null) 
                    return ErrorTypes.Validation.Because("the user to be updated can not be null");

                ApplicationUser user = _mapper.Map<ApplicationUser>(saveModel);

                bool isUpdateOperationASuccess = await _userRepository.UpdateAsync(user, saveModel.Password);

                return !isUpdateOperationASuccess ? ErrorTypes.OperationError.Because("Error updating the user") 
                    : new("User was updated succesfully") ;
            }
            catch
            {
                return ErrorTypes.Exceptions.Because("Critical error while trying to update the user");
            }
        } 
        public async Task<Result> DeleteAsync(string id)
        {
            try
            {
                if (id == default) 
                    return ErrorTypes.Validation.Because("id cant be empty");

                bool isDeleteOperationASuccess = await _userRepository.DeleteAsync(id);

                return !isDeleteOperationASuccess ? 
                    ErrorTypes.OperationError.Because("Error while deleting the user") : new("User was deleted successfully") ;
            }
            catch
            {
                return ErrorTypes.Exceptions.Because("Critical error deleting the user");
            }
        }
    }
}
