

namespace testing.Domain.Repositories.Identity
{
    public interface IUserRepository<TUser> where TUser : class
    {
        Task<List<TUser>> GetAllAsync(string role);
        Task<TUser> GetByIdAsync(string id);
        Task<bool> UpdateAsync(TUser entity, string newPassword);
        Task<bool> DeleteAsync(string Id);
        Task<bool> HandleUserStateAsync(string id);
    }
}
