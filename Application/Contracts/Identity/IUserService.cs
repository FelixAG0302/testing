

using testing.Application.Core;
using testing.Application.Models.Users;

namespace testing.Application.Contracts.Identity
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
