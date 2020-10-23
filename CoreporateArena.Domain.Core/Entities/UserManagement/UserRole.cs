using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateArena.Domain
{
    public class UserRole:BaseEntity
    {
        
        public int UserID { get; set; }
        public int RoleID { get; set; }
    }
}
