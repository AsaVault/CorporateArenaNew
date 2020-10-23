using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateArena.API.ViewModels
{
	public class AnswerQuestionViewModel
	{
		public int QuestionId { get; set; }
		public string Username { get; set; }
		public bool IsCorrect { get; set; }
	}
}
