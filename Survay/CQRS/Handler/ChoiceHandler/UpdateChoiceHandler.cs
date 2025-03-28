using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using Survay.CQRS.Command.ChoiceCommands;
using Survay.Models.database;
using Survay.Repositores.ChoiceRepo;
using Survay.Services.ChoiceServices;

namespace Survay.CQRS.Handler.ChoiceHandler
{
    public class UpdateChoiceHandler : IRequestHandler<UpdateChoiceCommand>
    {
        IWriteChoiceServices choiceServices;

        public UpdateChoiceHandler(IWriteChoiceServices choiceServices)
        {
            this.choiceServices = choiceServices;
        }



        public async Task Handle(UpdateChoiceCommand request, CancellationToken cancellationToken)
        {
            await choiceServices.Update(request.choiceId, request.newText);
        }
    }
}
