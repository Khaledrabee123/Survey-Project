using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Command;
using Survay.Models.database;
using Survay.Services.ChoiceServices;
using Survay.Services.QusetionServices;
using static System.Net.Mime.MediaTypeNames;

namespace Survay.CQRS.Handler
{
    public class AddChoiceToQuestionHandler : IRequestHandler<AddChoiceToQuestionCommand, int>
    {
        IChoiceServices choiceServices;
        IQusetionServices qusetionServices;

        public AddChoiceToQuestionHandler(IChoiceServices choiceServices, IQusetionServices qusetionServices)
        {
            this.choiceServices = choiceServices;
            this.qusetionServices = qusetionServices;
        }


        public async Task<int> Handle(AddChoiceToQuestionCommand request, CancellationToken cancellationToken)
        {

            var newChoice = choiceServices.MakeChoice(request.text);
            
            await qusetionServices.AddChoice(request.questionId, newChoice);

            
            return newChoice.OptionID;





        }
    }
}
