using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CorporateArena.DataAccess.Interfaces;
using CorporateArena.Domain;

namespace CorporateArena.DataAccess.Entities
{
    [Table("companies", Schema = "arenas")]
    public class Company : IEntity, IValidation
    {
        public Company()
        {
            Vacancies = new HashSet<Vacancy>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string LogoUrl { get; set; }

        [InverseProperty("Company")]
        public ICollection<Vacancy> Vacancies { get; set; }

        public bool IsDisplayed { get; set; }

        public bool IsDeleted { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedOn { get; set; }

        public List<string> ValidationErrors()
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(Name)) { errors.Add("Content is required"); }
            if (string.IsNullOrWhiteSpace(About)) { errors.Add("About is required"); }
            return errors;
        }
    }
}
