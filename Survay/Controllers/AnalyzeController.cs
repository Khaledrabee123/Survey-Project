using MediatR;
using Microsoft.AspNetCore.Mvc;
using Survay.CQRS.Query.SurveyQuerys;
using Survay.CQRS.Query.ResponseQuerys;

using Survay.Models.database;

namespace Survay.Controllers
{
    public class AnalyzeController : Controller
    {

        private readonly IMediator _mediator;

        public AnalyzeController(IMediator mediator)
        {
            _mediator = mediator;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        #region SurvayResponse
        public async Task<IActionResult> GetSurveyResults(int surveyId)
        {
            var results = await _mediator.Send(new SurveyResultsQuery(surveyId));
            return Json(results);
        }
        #endregion

        #region Analyze

        public async Task< IActionResult> analyze(int id)
        {
           
            ViewBag.totalresponce =await _mediator.Send(new TotalResponseForSurveyQuery(id));

            ViewBag.surveyId = id;
            return View();
        }

    }
    #endregion
}
