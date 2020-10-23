using CorporateArena.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class UserRoleRepo : IUserRoleRepo
    {
        private readonly TContext _context;

        public UserRoleRepo(TContext context)
        {
            _context = context;
        }


        public async Task<int> SaveUserRoleAsync(UserRole data)
        {
            try
            {
                var userRole = new UserRole
                {
                    DateCreated=DateTime.Now,
                    RoleID=data.RoleID,
                    UserID=data.UserID,
                    UserCreated=data.UserCreated
                };
                await _context.UserRoles.AddAsync(userRole);
                await _context.SaveChangesAsync();

                return userRole.ID;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
