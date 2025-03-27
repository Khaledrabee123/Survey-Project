using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using Survay.CQRS.Command;
using Survay.Models.database;
using Survay.Repositores.ChoiceRepo;
using Survay.Services.ChoiceServices;

namespace Survay.CQRS.Handler
{
    public class UpdateChoiceHandler : IRequestHandler<UpdateChoiceCommand>
    {
        IChoiceServices choiceServices;

        public UpdateChoiceHandler(IChoiceServices choiceServices)
        {
            this.choiceServices = choiceServices;
        }

        

        public async Task Handle(UpdateChoiceCommand request, CancellationToken cancellationToken)
        {
            await choiceServices.Update(request.choiceId, request.newText);
        }
    }
}
