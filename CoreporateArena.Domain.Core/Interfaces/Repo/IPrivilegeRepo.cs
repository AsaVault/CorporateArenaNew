using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static CorporateArena.Domain.Models;

namespace CorporateArena.Domain
{
    public interface IPrivilegeRepo
    {
        Task<Response> insertAsync(Privilege data);
        Task<bool> insertListAsync(List<Privilege> data);
        Task<int> deleteAsync(Privilege data);
        Task<int> updateAsync(Privilege data);
        Task<Privilege> getAsync(int ID);
        Task<List<Privilege>> getAllAsync();

    }
}
