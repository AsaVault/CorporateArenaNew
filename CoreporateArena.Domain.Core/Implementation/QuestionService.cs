using CorporateArena.DataAccess.Entities;
using CorporateArena.DataAccess.Interfaces;
using CorporateArena.UI.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateArena.API.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<QuestionAnswer> _answerRepository;
        private readonly IRepository<QuestionOption> _optionRepository;

        public QuestionService(IRepository<Question> questionRepository, 
            IRepository<QuestionAnswer> answerRepository, IRepository<QuestionOption> optionRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _optionRepository = optionRepository;
        }

        public List<Question> GetAllQuestion()
        {
            return _questionRepository.GetAll().ToList();
            // return _questionRepository.GetAll().Include(o => o.QuestionOptions).Include(a => a.QuestionAnswers).ToList();
        }

        public List<QuestionAnswer> GetAllAnswer()
        {
            return _answerRepository.GetAll().ToList();
        }

        public async Task<List<Question>> GetQuestionByPageAsync(int page, int pageSize)
        {
            var questions = _questionRepository.GetAll().Include(o => o.QuestionOptions)
                .Include(a => a.QuestionAnswers).OrderByDescending(n => n.CreatedOn);
            // var questions = _questionRepository.GetAll().OrderByDescending(n => n.CreatedOn);
            var currentQuestions = await PaginatedList<Question>.CreateAsync(questions, page, pageSize);
            return currentQuestions.ToList();
            // return _questionRepository.GetAll().ToList();
        }

        public Question GetQuestionById(int id)
        {
            return _questionRepository.GetAll().Include(x=>x.QuestionOptions).Include(x => x.QuestionAnswers).FirstOrDefault(x => x.Id == id);
        }

        public QuestionAnswer GetAnswerById(int id)
        {
            return _answerRepository.GetAll().FirstOrDefault(x => x.Id == id);
        }

        public QuestionAnswer GetAnswerByQuestionAndUserIds(int questionid, int userid)
        {
            return _answerRepository.GetAll().FirstOrDefault(x => x.QuestionId == questionid && x.UserId == userid);
        }

        public List<QuestionAnswer> GetAnswersByQuestionId(int id, bool? iscorrect)
        {
            return _answerRepository.GetAll().Where(x => x.QuestionId == id).ToList();
        }

        public async Task<bool> AddQuestion(Question newQuestion)
        {
            await _questionRepository.AddAsync(newQuestion);
            var result = Task.Run(() => _questionRepository.SaveAll());
            return await result;
        }

        public async Task<bool> AddOption(QuestionOption newQuestionOption)
        {
            await _optionRepository.AddAsync(newQuestionOption);
            var result = Task.Run(() => _optionRepository.SaveAll());
            return await result;
        }

        public async Task<bool> AnswerQuestion(QuestionAnswer answer)
        {
            await _answerRepository.AddAsync(answer);
            var result = Task.Run(() => _answerRepository.SaveAll());
            return await result;
        }
        public bool UpdateQuestion(Question art)
        {
            _questionRepository.Update(art);
            return _questionRepository.SaveAll();
        }

        public bool DeleteQuestion(Question art)
        {
            _questionRepository.Delete(art);
            return _questionRepository.SaveAll();
        }

    }
}
