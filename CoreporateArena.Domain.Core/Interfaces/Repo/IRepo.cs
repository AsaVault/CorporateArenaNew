using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IRepo<T>
    {
        Task<int> insertAsync(T data);
        Task<bool> insertListAsync(List<T> data);
        Task deleteAllByIDAsync(int ID);
        Task deleteAsync(int ID);
        Task updateAsync(T data);
        Task<T> getAsync(int ID);
        Task<List<T>> getAllAsync();
        Task<List<T>> getAllByIDAsync(int ID);
    }
}
