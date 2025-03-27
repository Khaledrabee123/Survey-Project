using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Survay.CQRS.Command;
using Survay.CQRS.Query;

namespace Survay.Controllers
{
    public class ChoiceController : Controller
    {
        private readonly IMediator mediator;
        private readonly ILogger<ChoiceController> _logger;

        public ChoiceController(IMediator Mediator, ILogger<ChoiceController> logger)
        {
            mediator = Mediator;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        #region Add Choice

        [HttpPost]
        public async Task<IActionResult> AddChoice(int questionId, string text)
        {
            var Choiceid = await mediator.Send(new AddChoiceToQuestionCommand(questionId, text));

            return Ok(new { message = "Choice added successfully", choiceId = Choiceid, text });
        }

        #endregion

        #region Update Choice

        [HttpPost]
        public async Task<IActionResult> UpdateChoice(int choiceId, string newText)
        {
            if (choiceId <= 0 || string.IsNullOrEmpty(newText))
            {
                return BadRequest("Invalid choice data.");
            }

            await mediator.Send(new UpdateChoiceCommand(choiceId, newText));

            return Ok(new { message = "Choice updated successfully", choiceId, newText });
        }

        #endregion

        #region Remove Choice
        [HttpPost]
        public async Task<IActionResult> RemoveChoice(int choiceId)
        {
            var choice = await mediator.Send(new GetChoiceByIdQuery(choiceId));

            if (choice == null)
            {
                return NotFound();
            }

            // Check if the choice is referenced in Answers
            var isReferenced = await mediator.Send(new IsChoiceHasAnswersQuery(choiceId));
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
