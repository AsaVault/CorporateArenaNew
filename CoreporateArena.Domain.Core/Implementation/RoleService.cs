using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public class RoleService : IRoleService
    {

        private readonly IRepo<RolePrivilege> _rpRepo;
        private readonly IRoleRepo _rRepo;
        private readonly IPrivilegeRepo _pRepo;

        public RoleService(IRepo<RolePrivilege> rpRepo, IRoleRepo rRepo, IPrivilegeRepo pRepo)
        {
            _rpRepo = rpRepo;
            _rRepo = rRepo;
            _pRepo = pRepo;
        }

        public async Task<SaveResponse> SaveRoleAsync(Role data)
        {
            var result = await _rRepo.insertAsync(data);

            // Assign privileges to role if ids was selected
            if (data.PrivilegeIDs != null)

                await AssignMultiplePrivileges(data);

            return result;
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            var result = await _rRepo.getAllAsync();
            return result;

        }

        public async Task<Role> GetRoleByIDAsync(int ID)
        {
            var result = await _rRepo.getAsync(ID);
            return result;

        }


        public async Task<Response> AssignPrivilegetoRoleAsync(int roleID, int privilegeID)
        {
            var result = await _rRepo.AssignPrivilegetoRoleAsync(roleID, privilegeID);
            return result;
        }

        public async Task<bool> AssignMultiplePrivileges(Role data)
        {

            var status = false;
            List<RolePrivilege> rolePrivileges = new List<RolePrivilege>();
            foreach (var pid in data.PrivilegeIDs)
            {
                var rp = new RolePrivilege
                {
                    RoleID = data.ID,
                    PrivilegeID = pid
                };
                rolePrivileges.Add(rp);

            }
            status = await _rpRepo.insertListAsync(rolePrivileges);


            return status;
        }

        public async Task<List<RolePrivilege>> GetAllRolePrivileges()
        {
            var rolePrivileges = await _rpRepo.getAllAsync();
            return rolePrivileges;
        }

        public async Task<SaveResponse> SaveSuperUser()
        {

            // save role to get ID

            int RID = await _rRepo.CreateSuperAsync();

            // get all prvileges and assign to role

            var privileges = await _pRepo.getAllAsync();
            var rolePrivileges = new List<RolePrivilege>();

            if (privileges != null)
            {
                foreach (var privilege in privileges)
                {
                    var rolePriv = new RolePrivilege
                    {
                        PrivilegeID = privilege.ID,
                        RoleID = RID
                    };

                    rolePrivileges.Add(rolePriv);
                }

                // Assign all privileges to the role

                await _rpRepo.insertListAsync(rolePrivileges);
            }

            return new SaveResponse { ID = RID, Result = "SuperUser Role Created", status = true };

        }

        public async Task<SaveResponse> SaveBasicRole()
        {

            // save role to get ID

            int RID = await _rRepo.CreateBasicAsync();
            return new SaveResponse { ID = RID, Result = "Basic Role Created", status = true };
        } 


    }
}
