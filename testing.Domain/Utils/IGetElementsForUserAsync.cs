

namespace testing.Domain.Utils
{
    public interface IGetElementsForUserAsync< TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllByUserIdAsync(string id);
    }
}
