using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
    }
}
