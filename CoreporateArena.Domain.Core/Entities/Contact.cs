using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CorporateArena.Domain
{
    public class Contact
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
