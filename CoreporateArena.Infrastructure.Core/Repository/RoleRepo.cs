using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class RoleRepo : IRoleRepo
    {

        private readonly TContext _context;
        public RoleRepo(TContext context)
        {
            _context = context;

        }

        public Task<int> deleteAsync(Role data)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Role>> getAllAsync()
        {
            try
            {
                var roles = await _context.Roles.ToListAsync();
                return roles;
            }
            catch(Exception ex)
            {
                throw ex;

            }
        }

        public async Task<Role> getRoleByNameAsync(string roleName)
        {
            try
            {
                var role = await _context.Roles.Where(x => x.Name == roleName).SingleOrDefaultAsync();
                return role;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public async Task<Role> getAsync(int ID)
        {
            try
            {
                var role = await _context.Roles.FindAsync(ID);


                var rolePrivs =await _context.RolePrivileges.Where(x => x.RoleID == ID).ToListAsync();


                if (rolePrivs != null)

                {
                    List<Privilege> privileges = new List<Privilege>();
                    foreach (var rolePriv in rolePrivs)
                    {

                        var priv = await _context.Privileges.FindAsync(rolePriv.PrivilegeID);
                        privileges.Add(priv);
                    }
                    role.Privileges = privileges;

                }




                return role;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<SaveResponse> insertAsync(Role data)
        {
            Role role;
            try
            {
                role = new Role
                {
                    DateCreated = DateTime.Now,
                    UserCreated = data.UserCreated,
                    DisplayName = data.DisplayName,
                    Name = data.Name

                };
                
                await _context.Roles.AddAsync(role);
                await _context.SaveChangesAsync();
                data.ID = role.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new SaveResponse {status=true,Result="Role was successfully created",ID=role.ID };
        }

        public Task<bool>  insertListAsync(List<Role> data)
        {
            throw new NotImplementedException();
        }

        public Task<int> updateAsync(Role data)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> AssignPrivilegetoRoleAsync(int roleID, int privilegeID)
        {

            var rolePrivilege = await _context.RolePrivileges.Where(x => x.RoleID == roleID && x.PrivilegeID == privilegeID).FirstOrDefaultAsync();
            // if rolePrivilege is not empty, then the privilege has already been assigned
            if (rolePrivilege != null)
                return new Response { Result = "Privilege already assigned", status = false };

            try
            {
                RolePrivilege data = new RolePrivilege
                {
                    RoleID = roleID,
                    PrivilegeID = privilegeID
                };



                await _context.RolePrivileges.AddAsync(data);
                await _context.SaveChangesAsync();
                return new Response { Result = "Successful", status = true };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<int> CreateSuperAsync()
        {
            try
            {
                var role = new Role
                {
                    DateCreated = DateTime.Now,
                    DisplayName = "SuperUser",
                    Name = "SuperUser"
                };

                await _context.Roles.AddAsync(role);
                await _context.SaveChangesAsync();
                return role.ID;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public async Task<int> CreateBasicAsync()
        {
            try
            {
                var role = new Role
                {
                    DateCreated = DateTime.Now,
                    DisplayName = "Basic",
                    Name = "Basic"
                };

                await _context.Roles.AddAsync(role);
                await _context.SaveChangesAsync();
                return role.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
