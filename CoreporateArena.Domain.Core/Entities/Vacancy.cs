using CorporateArena.DataAccess.Entities;
using CorporateArena.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CorporateArena.Domain
{
    public class Vacancy
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        [StringLength(150, MinimumLength = 5)]
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string JobSummary { get; set; }
        public string JobResponsibilities { get; set; }
        public string Salary { get; set; }
        public string Location { get; set; }

        public string JobExperiences { get; set; }
        public string JobSkills { get; set; }
        public string KeyPerformance { get; set; }
        public string RequiredKnowledge { get; set; }

        public DateTime DatePosted { get; set; }
        public DateTime DateExpired { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        [InverseProperty("Vacancies")]
        public virtual Company Company { get; set; }

        public bool IsDisplayed { get; set; }

        public bool IsDeleted { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedOn { get; set; }
        public int UserCreated { get; set; }
        public string Mode { get; set; }

        public int JobCategoryId { get; set; }

        [ForeignKey("JobCategoryId")]
        [InverseProperty("Vacancies")]
        public virtual JobCategory JobCategory { get; set; }
        public JobType JobType { get; set; }

    }
}
