using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateArena.Domain
{
    public class Vacancy
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string Location { get; set; }
        public string Company { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int UserCreated { get; set; }
        public string Mode { get; set; }
        public string Industry { get; set; }

    }
}
