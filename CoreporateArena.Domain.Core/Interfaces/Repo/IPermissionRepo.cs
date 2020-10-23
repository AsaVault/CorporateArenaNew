using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IPermissionRepo
    {
        Task<Response> AssignRoletoUserAsync(int roleID, int userID);
        Task<Response> AssignPrivilegetoRoleAsync(int roleID, int privilegeID);
        Task<bool> CopyRoletoAnotherUserAsync(int ownerID,int recipientID,int roleID);
        Task<User> GetUserWithRoleAsync(int ID);
    }
}
