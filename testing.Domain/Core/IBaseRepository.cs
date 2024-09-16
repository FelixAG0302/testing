using System.Linq.Expressions;


namespace testing.Domain.Core
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<bool> ExitsAsync(Expression<Func<TEntity, bool>> filter);
        Task<bool> SaveAsync(TEntity entity);
        Task<bool> DeleteAsync(int Id);
    }
    public interface IBaseCompleteRepository<TEntity>  : IBaseRepository<TEntity>
        where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);   
        Task<bool> UpdateAsync(TEntity entity);
            Task<IQueryable<TEntity>> GetQuerableEntity();
    }
}
