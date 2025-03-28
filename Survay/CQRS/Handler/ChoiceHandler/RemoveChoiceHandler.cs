using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using Survay.CQRS.Command.ChoiceCommands;
using Survay.Models.database;
using Survay.Services.ChoiceServices;

namespace Survay.CQRS.Handler.ChoiceHandler
{
    public class RemoveChoiceHandler : IRequestHandler<RemoveChoiceCommand>
    {
        IWriteChoiceServices writeChoiceServices;

        public RemoveChoiceHandler(IWriteChoiceServices writeChoiceServices)
        {
            this.writeChoiceServices = writeChoiceServices;
        }

        public Task Handle(RemoveChoiceCommand request, CancellationToken cancellationToken)
        {
            writeChoiceServices.Remove(request.Choice);
            return Task.CompletedTask;
        }
    }
}
