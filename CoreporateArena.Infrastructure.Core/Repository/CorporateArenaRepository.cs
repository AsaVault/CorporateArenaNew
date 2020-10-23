using CorporateArena.DataAccess.Interfaces;
using CorporateArena.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateArena.DataAccess.Repositories
{
    public class CorporateArenaRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly TContext _context;

        public CorporateArenaRepository(TContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _context.Set<TEntity>();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _context.AddAsync(entity);
                // await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Update)} entity must not be null");
            }

            try
            {
                _context.Update(entity);
                // await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Delete)} entity must not be null");
            }

            try
            {
                _context.Remove(entity);

                // return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be deleted");
            }
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
