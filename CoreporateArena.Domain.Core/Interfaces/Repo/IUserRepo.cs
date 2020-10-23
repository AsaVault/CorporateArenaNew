using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IUserRepo
    {
        Task<SaveResponse> RegisterUser(User data);

        Task<bool> ApproveUser(int ID);

        Task<List<User>> GetAllUsers();
        
        Task<Response> Login(string username, string password);
        
        Task<Response> AssignRoletoUser(int roleID, int userID);
        
        Task<User> GetUserWithRole(int ID);

        Task<Response> LoginWithToken(string token);

        Task<bool> GetUserByEmail(string email);

        Task<bool> GetUserByUsername(string username);
        Task<User> GetUserByUsernameUser(string username);

        Task<List<UserRole>> GetUserRoles();

        Task<int> CreateSystemUserAsync(int roleID);

        Task<User> GetUserByID(int ID);

        Task Update(User data);
    }
}
