using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public class Role:BaseEntity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        
        // To show all related privileges when fetching
        public List<Privilege> Privileges { get; set; }

        // Awaiting Review
        [NotMapped]
        public List<int> PrivilegeIDs { get; set; }

    }
}
