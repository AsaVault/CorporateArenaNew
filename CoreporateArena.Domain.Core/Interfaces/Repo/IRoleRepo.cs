using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IRoleRepo
    {
        Task<Response> AssignPrivilegetoRoleAsync(int roleID, int privilegeID);
        Task<SaveResponse> insertAsync(Role data);
        Task<bool> insertListAsync(List<Role> data);
        Task<int> deleteAsync(Role data);
        Task<int> updateAsync(Role data);
        Task<Role> getAsync(int ID);
        Task<Role> getRoleByNameAsync(string roleName);
        Task<List<Role>> getAllAsync();
        Task<int> CreateSuperAsync();
        Task<int> CreateBasicAsync();
    }
}
