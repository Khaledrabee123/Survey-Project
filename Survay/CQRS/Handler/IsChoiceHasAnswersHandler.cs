using MediatR;
using Survay.CQRS.Query;
using Survay.Models.database;
using Survay.Services.ChoiceServices;

namespace Survay.CQRS.Handler
{
    public class IsChoiceHasAnswersHandler : IRequestHandler<IsChoiceHasAnswersQuery, bool>
    {
        IChoiceServices choiceServices;

        public IsChoiceHasAnswersHandler(IChoiceServices choiceServices)
        {
            this.choiceServices = choiceServices;
        }

        

        public async Task<bool> Handle(IsChoiceHasAnswersQuery request, CancellationToken cancellationToken)
        {
            return choiceServices.IsChoiceHasAnswersQuery(request.choiceId);
            
        }
    }
}
