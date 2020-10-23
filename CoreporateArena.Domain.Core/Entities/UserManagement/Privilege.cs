using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public class Privilege 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public string Action {

            get;
            set;

        }
        public string Entity { get; set; }
    }


    

    public class Models
    {
        
        Dictionary<int, string> Aq = new Dictionary<int, string>();

        public IEnumerable<KeyValuePair<int,string>> GetActions()
        {
            Aq.Add(1, "Create");
            Aq.Add(2, "Read");
            Aq.Add(3, "Update");
            Aq.Add(4, "Delete");
            Aq.Add(5, "Like");
            Aq.Add(6, "Comment");

            var actions = Aq.ToList();
            return actions;
        }


        public static List<KeyValuePair<string, string>> Mods = new List<KeyValuePair<string, string>>()
        {

            new KeyValuePair<string, string>("User","User"),
            new KeyValuePair<string, string>("Role To User","UserRole"),
            new KeyValuePair<string, string>("Role","Role"),
            new KeyValuePair<string, string>("Privilege To Role","RolePrivilege"),
            new KeyValuePair<string, string>("Brain Teaser","BrainTeaser"),
            new KeyValuePair<string, string>("Vacancy","Vacancy"),
            new KeyValuePair<string, string>("Article","Article"),
            new KeyValuePair<string, string>("Article Comment","ArticleComment"),
            new KeyValuePair<string, string>("Traffic Updates","TrafficUpdates")

        };
        public enum MyEnum
        {
            Create, Read, Update, Delete
        }

        
    }
    
}
