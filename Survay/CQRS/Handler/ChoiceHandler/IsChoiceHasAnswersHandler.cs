using MediatR;
using Survay.CQRS.Query.ChoiceQuerys;
using Survay.Models.database;
using Survay.Services.ChoiceServices;

namespace Survay.CQRS.Handler.ChoiceHandler
{
    public class IsChoiceHasAnswersHandler : IRequestHandler<IsChoiceHasAnswersQuery, bool>
    {
        IReadChoiceServices readChoiceServices;

        public IsChoiceHasAnswersHandler(IReadChoiceServices readChoiceServices)
        {
            this.readChoiceServices = readChoiceServices;
        }



        public async Task<bool> Handle(IsChoiceHasAnswersQuery request, CancellationToken cancellationToken)
        {
            return readChoiceServices.IsChoiceHasAnswersQuery(request.choiceId);

        }
    }
}
