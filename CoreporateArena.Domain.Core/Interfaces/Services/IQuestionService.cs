using CorporateArena.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateArena.API.Services
{
    public interface IQuestionService
    {
        List<Question> GetAllQuestion();
        List<QuestionAnswer> GetAllAnswer();
        Task<List<Question>> GetQuestionByPageAsync(int page, int pageSize);
        Question GetQuestionById(int id);
        QuestionAnswer GetAnswerById(int id);
        QuestionAnswer GetAnswerByQuestionAndUserIds(int questionid, int userid);
        List<QuestionAnswer> GetAnswersByQuestionId(int id, bool? iscorrect);
        Task<bool> AddQuestion(Question question);
        Task<bool> AddOption(QuestionOption newQuestionOption);
        Task<bool> AnswerQuestion(QuestionAnswer answer);
        bool UpdateQuestion(Question question);
        bool DeleteQuestion(Question question);
    }
}
