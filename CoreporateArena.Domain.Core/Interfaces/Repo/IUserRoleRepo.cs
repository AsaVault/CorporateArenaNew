using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IUserRoleRepo
    {
        Task<int> SaveUserRoleAsync(UserRole data);
    }
}
