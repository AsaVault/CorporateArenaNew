using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IRoleService
    {

        Task<SaveResponse> SaveRoleAsync(Role data);
        Task<List<Role>> GetAllRolesAsync();
       Task<Role> GetRoleByIDAsync(int ID);
       Task<Response> AssignPrivilegetoRoleAsync(int roleID, int privilegeID);
        Task<List<RolePrivilege>> GetAllRolePrivileges();
        Task<SaveResponse> SaveSuperUser();
        Task<SaveResponse> SaveBasicRole();
    }
}
