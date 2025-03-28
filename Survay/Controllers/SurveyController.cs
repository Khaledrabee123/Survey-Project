using System.Globalization;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Command.SurvayCommnds;
using Survay.CQRS.Query.SurveyQuerys;
using Survay.DTOs;
using Survay.Models.database;
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

        #region Create Survey View 
        [HttpGet()]
        public IActionResult Create(surveyDTO servayDTO)
        {
            return View(servayDTO);
        }
        #endregion

        #region add Surveys
        public IActionResult SubmitSurvey(surveyDTO surveyDto)
        {
            Survey survey = helper.ConvertToSurvey(surveyDto);

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
            var userSurevaysDTO =await mediator.Send(new UserSurveysQuery(UserId));

            return View(userSurevaysDTO);
        }
        #endregion

        #region  update  survey name and description
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
      
            var Survey=await mediator.Send(new GetSurveyToEditQuery(id));     
     
            return View(Survey);
        }
        #endregion

        #region Delete Survay
        [HttpPost]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            await mediator.Send(new DeleteSurveycommand(id));

            logger.LogInformation($"The survey with ID = {id} has been removed");

            return RedirectToAction("Index", "Home");
        }
        #endregion




      



    }
}
