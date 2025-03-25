using System.Globalization;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Command;
using Survay.CQRS.Query;
using Survay.Models.database;
using Survay.Models.DTO;
using Survay.Models.DTOs;
using WebApplication3.Models;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.Controllers
{

    [Authorize]
    public class SurveyController : Controller
    {
        private readonly IMediator mediator;
        private ILogger<SurveyController> logger;

        public SurveyController(IMediator mediator, ILogger<SurveyController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Create
        [HttpGet()]
        public IActionResult Create(serveyDTO servayDTO)
        {
            return View(servayDTO);
        }
        #endregion

        #region add Surveys
        public IActionResult SubmitSurvey(serveyDTO surveyDto)
        {
            Servey survey = helper.ConvertToSurvey(surveyDto);

            survey.UserID = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            mediator.Send(new AddSurveyCommand(survey));

            logger.LogInformation($"User with ID {survey.UserID} has added a survey." );

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Get User Surevys
        public async Task< IActionResult> Surevys()
        {
            String UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userSurevaysDTO =await mediator.Send(new UserSurvaysQuery(UserId));

            return View(userSurevaysDTO);
        }
        #endregion

        #region  update the survey name and description
        [HttpPost]
        public async Task<IActionResult> UpdateSurvey(int surveyId, string field, string value)
        {

            bool IsCompleted = await mediator.Send(new UpdateSurveyCommand(surveyId, field, value));


            return IsCompleted ? Ok() : BadRequest();
        }
        #endregion

        #region Get surevy to edit 
        public async Task< IActionResult> Edit(int id)
        {
      
            var Survey=await mediator.Send(new GetSurvayToEditQuery(id));     
     
            return View(Survey);
        }
        #endregion

        #region Delete Survay
        [HttpPost]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            await mediator.Send(new DeleteSurvaycommand(id));

            logger.LogInformation($"The survey with ID = {id} has been removed");

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Add Question
        [HttpPost]
        public async Task< IActionResult> AddQuestion(int surveyId, string text)
        {
            var AddQuestion =await mediator.Send(new AddQuestionCommand(surveyId, text));
            return Json(new { questionId = AddQuestion, text = text });
        }

        #endregion

        #region Update Question
        [HttpPost]
        public async Task<IActionResult> UpdateQuestion(int questionId, string field, string value)
        {
            bool Issuccessed =await mediator.Send(new UpdateQuestionCommand(questionId, field, value));
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


        #region Add Choice

        [HttpPost]
        public async Task< IActionResult >AddChoice(int questionId, string text)
        {
            var Choiceid =await mediator.Send(new AddChoiceCommand(questionId, text));

            return Ok(new { message = "Choice added successfully", choiceId = Choiceid, text });
        }

        #endregion

        #region Update Choice

        [HttpPost]
        public async Task< IActionResult> UpdateChoice(int choiceId, string newText)
        {
            if (choiceId <= 0 || string.IsNullOrEmpty(newText))
            {
                return BadRequest("Invalid choice data.");
            }

            await   mediator.Send(new UpdateChoiceCommand(choiceId, newText));

            return Ok(new { message = "Choice updated successfully", choiceId, newText });
        }

        #endregion

        #region Remove Choice
        [HttpPost]
        public async Task< IActionResult> RemoveChoice(int choiceId)
        {
            var choice = await mediator.Send(new GetChoiceByIdQuery(choiceId));

            if (choice == null)
            {
                return NotFound();
            }

            // Check if the choice is referenced in Answers
            var isReferenced =await mediator.Send(new IsChoiceHasAnswersQuery(choiceId));
            if (isReferenced)
            {
                return BadRequest("This choice is already used in answers and cannot be removed.");
            }

            await mediator.Send(new RemoveChoiceCommand(choice));

            return Ok();
        }
        #endregion


      



    }
}
