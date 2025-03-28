using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Query.ChoiceQuerys;
using Survay.Models.database;
using Survay.Services.ChoiceServices;

namespace Survay.CQRS.Handler.ChoiceHandler
{
    public class GetChoiceByIdHandler : IRequestHandler<GetChoiceByIdQuery, Choice>
    {
        IReadChoiceServices readChoiceServices;

        public GetChoiceByIdHandler(IReadChoiceServices readChoiceServices)
        {
            this.readChoiceServices = readChoiceServices;
        }



        public async Task<Choice> Handle(GetChoiceByIdQuery request, CancellationToken cancellationToken)
        {
            return await readChoiceServices.Get(request.ChoiceId);
        }
    }
}
