using CorporateArena.DataAccess.Interfaces;
using CorporateArena.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CorporateArena.DataAccess.Entities
{
	[Table("questions", Schema = "arenas")]
	public class Question : IEntity, IValidation
	{
		public Question()
		{
			QuestionOptions = new HashSet<QuestionOption>();
			QuestionAnswers = new HashSet<QuestionAnswer>();
		}
		public int Id { get; set; }
		public string Content { get; set; }
		[InverseProperty("Question")]
		public ICollection<QuestionOption> QuestionOptions { get; set; }
		[InverseProperty("Question")]
		public ICollection<QuestionAnswer> QuestionAnswers { get; set; }
		public List<string> ValidationErrors()
		{
			var errors = new List<string>();
			if (string.IsNullOrWhiteSpace(Content)) { errors.Add("Content is required"); }
			return errors;
		}
		public bool IsDisplayed { get; set; }

		public bool IsDeleted { get; set; }
		[DataType(DataType.Date)]
		public DateTime CreatedOn { get; set; }
		[DataType(DataType.Date)]
		public DateTime UpdatedOn { get; set; }
	}

	[Table("questionoptions", Schema = "arenas")]
	public class QuestionOption : IEntity, IValidation
	{
		public int Id { get; set; }
		public string Content { get; set; }
		public string OptionLetter { get; set; }
		public int QuestionId { get; set; }

		[ForeignKey("QuestionId")]
		[InverseProperty("QuestionOptions")]
		public virtual Question Question { get; set; }
		public bool IsCorrect { get; set; }
		public List<string> ValidationErrors()
		{
			var errors = new List<string>();
			if (string.IsNullOrWhiteSpace(Content)) { errors.Add("Content is required"); }
			if (string.IsNullOrWhiteSpace(OptionLetter)) { errors.Add("OptionLetter is required"); }
			return errors;
		}
		public bool IsDisplayed { get; set; }

		public bool IsDeleted { get; set; }
		[DataType(DataType.Date)]
		public DateTime CreatedOn { get; set; }
		[DataType(DataType.Date)]
		public DateTime UpdatedOn { get; set; }
	}

	[Table("questionanswers", Schema = "arenas")]
	public class QuestionAnswer : IEntity
	{
		public int Id { get; set; }
		public int QuestionId { get; set; }

		[ForeignKey("QuestionId")]
		[InverseProperty("QuestionAnswers")]
		public virtual Question Question { get; set; }
		public int UserId { get; set; }

		[ForeignKey("UserId")]
		[InverseProperty("UserAnswers")]
		public virtual User User { get; set; }
		public bool IsCorrect { get; set; }
		public bool IsDisplayed { get; set; }

		public bool IsDeleted { get; set; }
		[DataType(DataType.Date)]
		public DateTime CreatedOn { get; set; }
		[DataType(DataType.Date)]
		public DateTime UpdatedOn { get; set; }
	}
}
