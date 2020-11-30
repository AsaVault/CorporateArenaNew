using CorporateArena.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain.Core.Entities
{
    [Table("jobCategories", Schema = "arenas")]
    public class JobCategory:IEntity, IValidation
    {
        public JobCategory()
        {
            Vacancies = new HashSet<Vacancy>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        [InverseProperty("JobCategory")]
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
            if (string.IsNullOrWhiteSpace(Description)) { errors.Add("Description is required"); }
            return errors;
        }
    }
}
