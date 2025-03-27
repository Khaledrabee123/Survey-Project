using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using Survay.CQRS.Command;
using Survay.Models.database;
using Survay.Services.ChoiceServices;

namespace Survay.CQRS.Handler
{
    public class RemoveChoiceHandler : IRequestHandler<RemoveChoiceCommand>
    {
        IChoiceServices choiceServices;

        public RemoveChoiceHandler(IChoiceServices choiceServices)
        {
            this.choiceServices = choiceServices;
        }

        public Task Handle(RemoveChoiceCommand request, CancellationToken cancellationToken)
        {
            choiceServices.Remove(request.Choice);
            return Task.CompletedTask;
        }
    }
}
