

namespace testing.Domain.Repositories.Identity
{
    public interface IUserRepository<TUser> where TUser : class
    {
        Task<List<TUser>> GetAllAsync();
        Task<TUser> GetByIdAsync(string id);
        Task<bool> UpdateAsync(TUser entity);
        Task<bool> DeleteAsync(string Id);
    }
}
