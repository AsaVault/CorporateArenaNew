using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateArena.Domain
{
    public class BrainTeaser
    {
        public int ID { get; set; }
        public string Riddle { get; set; }
        public List<BrainTeaserAnswer> BrainTeaserAnswers { get; set; }
        public List<BrainTeaserWinner> BrainTeaserWinners { get; set; }
        public int UserCreated { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CorrectAnswer { get; set; }
        public string Gift { get; set; }
        public bool isApproved { get; set; }
        public bool isDeleted { get; set; }


    }

    public class BrainTeaserAnswer
    {
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserCreated { get; set; }
        public string UserName { get; set; }
        public string Answer { get; set; }
        public bool isApproved { get; set; }
        public int BrainTeaserID { get; set; }
    }

    public class BrainTeaserWinner
    {
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserCreated { get; set; }
        public string UserName { get; set; }
        public string Answer { get; set; }
        public bool isDisplayed { get; set; }
        public int BrainTeaserID { get; set; }
    }
}
