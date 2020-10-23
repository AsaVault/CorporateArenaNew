using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CorporateArena.Domain
{
    public class RolePrivilege
    {
        public int ID { get; set; }

        public int RoleID { get; set; }

        public int PrivilegeID { get; set; }
    }
}
