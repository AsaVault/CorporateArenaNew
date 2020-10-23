using CorporateArena.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public class User : BaseEntity
    {
        
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        // To show role when fetching
        public Role Role { get; set; }

        // Awaiting Review 
        public int RoleID { get; set; }
        [InverseProperty("User")]
        public ICollection<QuestionAnswer> UserAnswers { get; set; }
    }
}
