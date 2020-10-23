using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CorporateArena.API.Services;
using CorporateArena.API.ViewModels;
using CorporateArena.DataAccess.Entities;
using CorporateArena.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorporateArena.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IUserService _userService;

        public QuestionController(IQuestionService questionService, IUserService userService)
        {
            _questionService = questionService;
            _userService = userService;
        }

        // [HasPermission(PermEnums.ReadUser)]
        [HttpGet("{page}/{pageSize}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                var questions = await _questionService.GetQuestionByPageAsync(page, pageSize);
                return StatusCode((int)HttpStatusCode.OK, questions);
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var question = _questionService.GetQuestionById(id);
                if (question == null) return NotFound();
                return StatusCode((int)HttpStatusCode.OK, question);
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }

        [HttpPost("")]
        public async Task<ActionResult> PostAsync([FromBody] Question question)
        {
            try
            {

                if (question.ValidationErrors().Any())
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed, string.Join(" | ", question.ValidationErrors()));
                }

                var newQuestion = new Question
                {
                    Content = question.Content,
                    IsDeleted = false,
                    IsDisplayed = true,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                };

                var result = await _questionService.AddQuestion(newQuestion);

                if (result) return StatusCode((int)HttpStatusCode.Created, "Question created successfully !!!");
                return StatusCode((int)HttpStatusCode.OK, "Question not created !!!");
            }

            //catch (Exception ex) { return this.custom_error(ex); } // TODO
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }

        [HttpPost("option/{id}")]
        public async Task<ActionResult> PostOptionAsync([FromBody] QuestionOption questionOption, int id)
        {
            try
            {
                var entity = _questionService.GetQuestionById(id);
                if (entity == null) return NotFound();

                if (questionOption.ValidationErrors().Any())
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed, string.Join(" | ", questionOption.ValidationErrors()));
                }

                var newQuestionOption = new QuestionOption
                {
                    QuestionId = id,
                    // Question = entity,
                    Content = questionOption.Content,
                    OptionLetter = questionOption.OptionLetter,
                    IsCorrect = questionOption.IsCorrect,
                    IsDeleted = false,
                    IsDisplayed = true,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                };

                var result = await _questionService.AddOption(newQuestionOption);

                if (result) return StatusCode((int)HttpStatusCode.Created, "Option added successfully !!!");
                return StatusCode((int)HttpStatusCode.OK, "Option not added !!!");
            }

            //catch (Exception ex) { return this.custom_error(ex); } // TODO
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }

        [HttpPost("answer/{id}")]
        public async Task<ActionResult> PostAnswerAsync([FromBody] AnswerQuestionViewModel answerQuestionViewModel, int id)
        {
            try
            {
                var entity = _questionService.GetQuestionById(id);
                if (entity == null) return NotFound();

                var username = answerQuestionViewModel.Username;

                if (string.IsNullOrWhiteSpace(username))
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, string.Format("Please enter a valid username", username));
                }

                var user = await _userService.GetUserByUsernameUser(username);

                if (user == null)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, string.Format("{0}  is not associated with an account", username));
                }

                var answer = _questionService.GetAnswerByQuestionAndUserIds(id, user.ID);
                if (answer != null)
                {
                    return StatusCode((int)HttpStatusCode.OK, "You have answered the question already !!!");
                }

                answer = new QuestionAnswer
                {
                    QuestionId = id,
                    UserId = user.ID,
                    IsCorrect = answerQuestionViewModel.IsCorrect,
                    IsDeleted = false,
                    IsDisplayed = true,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                };

                var result = await _questionService.AnswerQuestion(answer);

                if (result) return StatusCode((int)HttpStatusCode.Created, "Question answered successfully !!!");
                return StatusCode((int)HttpStatusCode.OK, "Question not answered !!!");
            }
            catch (Exception ex) { return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message); }
        }

        [AllowAnonymous]
        [HttpPatch("{id}")]
        public IActionResult Patch([FromBody] Question question, int id)
        {
            try
            {
                var entity = _questionService.GetQuestionById(id);
                if (entity == null) return NotFound();

                if (question.ValidationErrors().Any())
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed, string.Join(" | ", question.ValidationErrors()));
                }

                // update question
                // question.Title = createQuestionViewModel.Title;
                entity.Content = question.Content;
                entity.UpdatedOn = DateTime.Now;

                if (_questionService.UpdateQuestion(entity)) return StatusCode((int)HttpStatusCode.OK, "Question updated successfully !!!");
                return StatusCode((int)HttpStatusCode.OK, "Question not updated !!!");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var question = _questionService.GetQuestionById(id);
                if (question == null) return NotFound();

                if (_questionService.DeleteQuestion(question)) return StatusCode((int)HttpStatusCode.OK, "Question deleted successfully !!!");
                return StatusCode((int)HttpStatusCode.OK, "Question not deleted !!!");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
