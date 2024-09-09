
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
                if (role == null) return new("Role of the users to get cant be null", false);

                List<ApplicationUser> usersGetted = await _userRepository.GetAllAsync(role);

                return new("User's get was successfull", _mapper.Map<List<UserModel>>(usersGetted));
            }
            catch
            {
                return new("Critical error getting the user's ", false);
            }
        }

        public async Task<Result<UserModel>> GetByIdAsync(string id)
        {
            try
            {
                if (id == default) return new("id can not be empty", false);

                ApplicationUser userGettedById = await _userRepository.GetByIdAsync(id);

                return new("User get was successfull", _mapper.Map<UserModel>(userGettedById));
            }
            catch
            {
                return new("Critical error while getting the requested user by id", false);
            }
        }

        public async Task<Result> HandleUserStateAsync(string id)
        {
            try
            {
                if (id == default) return new("id can not be empty", false);

                bool isOperationASuccess = await _userRepository.HandleUserStateAsync(id);

                return isOperationASuccess ? new("state update was a success") : new("Error while trying to update the user state", false);
            }
            catch
            {
                return new("Critical error while changing the user stated");
            }
        }

        public async Task<Result> UpdateAsync(SaveUserModel saveModel)
        {
            try
            {
                if (saveModel == null) return new("the user to be updated can not be null", false);

                ApplicationUser user = _mapper.Map<ApplicationUser>(saveModel);

                bool isUpdateOperationASuccess = await _userRepository.UpdateAsync(user, saveModel.Password);

                return isUpdateOperationASuccess ? new("User was updated succesfully") : new("Error updating the user", false);
            }
            catch
            {
                return new("Critical error while trying to update the user", false);
            }
        } 
        public async Task<Result> DeleteAsync(string id)
        {
            try
            {
                if (id == default) return new("id cant be empty", false);

                bool isDeleteOperationASuccess = await _userRepository.DeleteAsync(id);

                return isDeleteOperationASuccess ? new("User was deleted successfully") : new("Error while deleting the user", false);
            }
            catch
            {
                return new("Critical error deleting the user", false);
            }
        }
    }
}
