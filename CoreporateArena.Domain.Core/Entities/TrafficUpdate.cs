using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateArena.Domain
{
    public class TrafficUpdate
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserCreated { get; set; }
        public List<TrafficComment> TrafficUpdateComments { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class TrafficComment
    {
        public int ID { get; set; }
        public int UserCreated { get; set; }
        public DateTime DateCreated { get; set; }
        public string Comment { get; set; }
        public int TrafficUpdateID { get; set; }

    }
}
