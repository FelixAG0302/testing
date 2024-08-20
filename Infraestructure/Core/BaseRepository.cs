using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using testing.Domain.Core;

namespace Infraestructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly AplicationContext _context;
        private DbSet<TEntity> _entities;
        public BaseRepository(AplicationContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }
        public virtual async Task<bool> ExitsAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _entities.AnyAsync(filter);
        }
        public virtual async Task SaveAsync(TEntity entity)
        {
            try
            {
                _entities.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch 
            {
                throw;
            }
        }


        public virtual async Task<bool> DeleteAsync(int Id)
        {
            try
            {
                TEntity entityToBeDeleted = await _entities.FindAsync(Id);

                if (entityToBeDeleted == null) return false;
                
                _context.Remove(entityToBeDeleted);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }

    public class BaseCompleteRepository<TEntity> : BaseRepository<TEntity>, IBaseCompleteRepository<TEntity>
    where TEntity : class
    {
        private readonly AplicationContext _context;
        private DbSet<TEntity> _entities;

        public BaseCompleteRepository(AplicationContext context) : base(context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            try
            {
                _entities.Attach(entity);
                _entities.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
