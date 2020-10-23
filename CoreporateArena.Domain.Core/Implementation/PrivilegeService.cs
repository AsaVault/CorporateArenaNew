using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static CorporateArena.Domain.Models;

namespace CorporateArena.Domain
{
    public class PrivilegeService : IPrivilegeService
    {

        private readonly IPrivilegeRepo _repo;

        public PrivilegeService(IPrivilegeRepo repo)
        {
            _repo = repo;
        }


        public Task<int> deleteAsync(Privilege data)
        {
            throw new NotImplementedException();
        }

        public List<string> GetActionsAsync()
        {
            var acts = new List<string>(Enum.GetNames(typeof(MyEnum)));
            return acts;
        }

        public async Task<List<Privilege>> getAllAsync()
        {
            var result = await _repo.getAllAsync();
            return result;
        }

        public Task<Privilege> getAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public List<KeyValuePair<string, string>> GetModelsAsync()
        {
            return Mods;
        }

        public async Task<Response> insertAsync(Privilege data)
        {
            var result = await _repo.insertAsync(data);
            return result;
        }

        public async Task<SaveResponse> insertListAsync()
        {

            var status = false;
            List<Privilege> privileges = new List<Privilege>();

            foreach (var model in GetModelsAsync())
            {
                foreach (var actions in GetActionsAsync())
                {
                    var privilege = new Privilege
                    {
                        
                        Action = actions,
                        Entity = model.Value,
                        DisplayName = actions + ' ' + model.Value,
                        Name = actions + model.Value


                    };

                    privileges.Add(privilege);
                }

            }

            status=await _repo.insertListAsync(privileges);
            if (status == false)
                return new SaveResponse { Result = "Privileges was not saved", status = status };
            return new SaveResponse { Result = "Privileges saved", status = status };

        }

        public Task<int> updateAsync(Privilege data)
        {
            throw new NotImplementedException();
        }
    }
}
