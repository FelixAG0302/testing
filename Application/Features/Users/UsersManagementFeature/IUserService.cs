using testing.Application.Core;
using testing.Application.Features.Users.AccountFeature.Model;
using testing.Application.Features.Users.UsersManagementFeature.Models;

namespace testing.Application.Features.Users.UsersManagementFeature
{
    public interface IUserService
    {
        Task<Result<List<UserModel>>> GetAllAsync(string role);
        Task<Result<UserModel>> GetByIdAsync(string id);
        Task<Result> UpdateAsync(SaveUserModel saveModel);
        Task<Result> DeleteAsync(string id);
        Task<Result> HandleUserStateAsync(string id);
    }
}
