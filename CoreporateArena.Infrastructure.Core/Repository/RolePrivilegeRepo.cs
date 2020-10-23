using CorporateArena.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class RolePrivilegeRepo : IRepo<RolePrivilege>
    {
        private readonly TContext _context;
        public RolePrivilegeRepo(TContext context)
        {
            _context = context;

        }

        public Task deleteAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task deleteAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RolePrivilege>> getAllAsync()
        {
            try
            {
                var rolePrivileges = await _context.RolePrivileges.ToListAsync();
                return rolePrivileges;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<RolePrivilege>> getAllByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<RolePrivilege> getAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<int> insertAsync(RolePrivilege data)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> insertListAsync(List<RolePrivilege> data)
        {
            try 
            {
                await _context.RolePrivileges.AddRangeAsync(data);
                await _context.SaveChangesAsync();
                return true;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task updateAsync(RolePrivilege data)
        {
            throw new NotImplementedException();
        }
        //public async Task<Response> AssignPrivilegetoRoleAsync(int roleID, int privilegeID)
        //{

        //    var rolePrivilege = await _context.RolePrivileges.Where(x => x.RoleID == roleID && x.PrivilegeID == privilegeID).FirstOrDefaultAsync();
        //    // if rolePrivilege is not empty, then the privilege has already been assigned
        //    if (rolePrivilege != null)
        //        return new Response { Result="Privilege already assigned",status=false};

        //    try
        //    {
        //        RolePrivilege data = new RolePrivilege
        //        {
        //            RoleID = roleID,
        //            PrivilegeID = privilegeID
        //        };



        //        await _context.RolePrivileges.AddAsync(data);
        //        await _context.SaveChangesAsync();
        //        return new Response { Result = "Successful", status = true };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    // throw new NotImplementedException();
        //}

        //public async Task<Response> AssignRoletoUserAsync(int roleID, int userID)
        //{
        //    var userRole = await _context.UserRoles.Where(x => x.RoleID == roleID && x.UserID == userID).FirstOrDefaultAsync();
        //    if(userRole!=null)
        //        return new Response { status = false, Result = "Role has already been assigned to this user" };

        //    try
        //    {
        //        UserRole data = new UserRole
        //        {
        //            RoleID = roleID,
        //            UserID=userID
        //        };





        //        await _context.UserRoles.AddAsync(data);
        //        await _context.SaveChangesAsync();
        //        return new Response {status=true,Result="Successful"};
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public Task<bool> CopyRoletoAnotherUserAsync(int ownerID, int recipientID, int roleID)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<User> GetUserWithRoleAsync(int ID)
        //{
        //    try
        //    {
        //        var user = await _context.AppUsers.FindAsync(ID);
        //        var userRole = await _context.UserRoles.Where(x => x.UserID == ID).SingleOrDefaultAsync();

        //        if(userRole!=null) user.Role = await _context.Roles.SingleAsync();


        //        return user;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}









        //public async Task<User> GetUserWithRole(int ID)
        //{

        //    try
        //    {
        //        var user=await _context.AppUsers.FindAsync(ID);
        //        return user;
        //       // user.Role= await _context.Roles.Where(x=>x.use)
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
