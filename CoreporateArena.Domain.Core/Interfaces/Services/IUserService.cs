using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IUserService
    {
        Task<SaveResponse> RegisterUserAsync(User data);
        Task<bool> ApproveUserAsync(int ID);
        Task<List<User>> GetAllUsersAsync();
        Task<Response> LoginAsync(string username, string password);
        Task<Response> AssignRoletoUserAsync(int roleID, int userID);
        Task<User> GetUserWithRoleAsync(int ID);
        Task<Response> LoginWithTokenAsync(string token);
        Task<bool> CheckIfUserExist(int ID);
        Task<bool> CheckforPermission(int ID, string name);
        Task<List<UserRole>> GetUserRoles();
        Task<bool> GetUserByUsername(string username);
        Task<User> GetUserByUsernameUser(string username);
        Task<SaveResponse> ActivateSystemUserAsync();
    }
}
