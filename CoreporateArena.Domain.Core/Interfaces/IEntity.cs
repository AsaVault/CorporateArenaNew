using System;
using System.ComponentModel.DataAnnotations;

namespace CorporateArena.DataAccess.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }

        bool IsDisplayed { get; set; }

        bool IsDeleted { get; set; }
        [DataType(DataType.Date)]
        DateTime CreatedOn { get; set; }
        [DataType(DataType.Date)]
        DateTime UpdatedOn { get; set; }
    }
}
