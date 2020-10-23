using System.Linq;
using System.Threading.Tasks;

namespace CorporateArena.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> AddAsync(TEntity entity);

        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        bool SaveAll();
    }
}
