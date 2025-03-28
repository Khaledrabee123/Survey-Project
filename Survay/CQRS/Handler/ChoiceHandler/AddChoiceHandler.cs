using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Command.ChoiceCommands;
using Survay.Models.database;
using Survay.Services.ChoiceServices;
using Survay.Services.QusetionServices;
using static System.Net.Mime.MediaTypeNames;

namespace Survay.CQRS.Handler.ChoiceHandler
{
    public class AddChoiceToQuestionHandler : IRequestHandler<AddChoiceToQuestionCommand, int>
    {
        IReadChoiceServices readChoiceServices;
        IWriteQusetionServices writeQusetionServices;

        public AddChoiceToQuestionHandler(IReadChoiceServices readChoiceServices, IWriteQusetionServices writeQusetionServices)
        {
            this.readChoiceServices = readChoiceServices;
            this.writeQusetionServices = writeQusetionServices;
        }


        public async Task<int> Handle(AddChoiceToQuestionCommand request, CancellationToken cancellationToken)
        {

            var newChoice = readChoiceServices.MakeChoice(request.text);

            await writeQusetionServices.AddChoice(request.questionId, newChoice);


            return newChoice.OptionID;





        }
    }
}
