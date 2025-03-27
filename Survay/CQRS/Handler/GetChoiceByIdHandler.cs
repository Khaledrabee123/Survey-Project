using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Query;
using Survay.Models.database;
using Survay.Services.ChoiceServices;

namespace Survay.CQRS.Handler
{
    public class GetChoiceByIdHandler : IRequestHandler<GetChoiceByIdQuery, Choice>
    {
        IChoiceServices choiceServices;

        public GetChoiceByIdHandler(IChoiceServices choiceServices)
        {
            this.choiceServices = choiceServices;
        }

     

        public async Task<Choice> Handle(GetChoiceByIdQuery request, CancellationToken cancellationToken)
        {
            return await choiceServices.Get(request.ChoiceId);
        }
    }
}
