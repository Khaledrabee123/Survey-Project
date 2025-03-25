using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Survay.CQRS.Command;
using Survay.CQRS.Query;
using Survay.Models.database;
using Survay.Models.DTO;
using WebApplication3.Models;

namespace Survay.Controllers
{
    public class ResponseController : Controller
    {
        private readonly IMediator mediator;
        private  ILogger<ResponseController> logger;
        public ResponseController(IMediator mediator, ILogger<ResponseController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Share
        public IActionResult Share(int id)
        {
            var surveyUrl = Url.Action("Response", "Response", new { id = id }, protocol: Request.Scheme);

            ViewBag.SurveyUrl = surveyUrl;
            return View();

        }
        #endregion

        #region GetSurevayToResponse
        
        public async Task <IActionResult> Response(int id)
        {
            var s =await mediator.Send(new ResponseToSurvayQuery(id)); 
            return View(s);
        }
        #endregion

        #region SubmitResponse
        public IActionResult SubmitResponse(ResponceDTO responceDTO)
        {

            Response UserResponse = helper.MapToResponse(responceDTO);
            
            mediator.Send(new AddResponseCommand(UserResponse));

            logger.LogInformation($"User with id {UserResponse.UserID} had response to the survay with id {UserResponse.SurveyID}");

            return RedirectToAction("Index", "Home");
        }
        #endregion

    }
}
