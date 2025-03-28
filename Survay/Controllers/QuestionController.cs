using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Survay.CQRS.Command;
using Survay.CQRS.Query;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Globalization;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Command.SurvayCommnds;
using Survay.CQRS.Command.QuserionCommands;

using Survay.CQRS.Query;
using Survay.Models.database;

using WebApplication3.Models;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.Controllers
{
    [Authorize]
    
    public class QuestionController : Controller
    {
        private readonly IMediator mediator;
        private readonly ILogger<QuestionController> _logger;


        public QuestionController(IMediator Mediator, ILogger<QuestionController> logger)
        {
            mediator = Mediator;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region Add Question

        [HttpPost]
        public async Task<IActionResult> AddQuestion(int surveyId, string text)
        {
            var questionId = await mediator.Send(new AddQuestionToSurveyCommand(surveyId, text));
            return Json(new { questionId = questionId, text = text });
        }

        #endregion

        #region Update Question
        [HttpPost]
        public async Task<IActionResult> UpdateQuestion(int questionId, string field, string value)
        {
            bool Issuccessed = await mediator.Send(new UpdateQuestionCommand(questionId, field, value));
            return Ok(new { success = true });
        }
        #endregion

        #region Delete Question
        [HttpPost]
        public async Task<IActionResult> DeleteQuestion(int questionId)
        {
            bool isSuccess = await mediator.Send(new RemoveQuestionCommand(questionId));
            return Json(new { success = true });
        }
        #endregion

    }
}

