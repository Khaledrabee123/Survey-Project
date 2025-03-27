using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Command;
using Survay.Models.database;
using Survay.Services.QusetionServices;

namespace Survay.CQRS.Handler
{
    public class RemoveQuestionHandler : IRequestHandler<RemoveQuestionCommand, bool>
    {
        IQusetionServices qusetionServices;

        public RemoveQuestionHandler(IQusetionServices qusetionServices)
        {
            this.qusetionServices = qusetionServices;
        }

      

        public async Task<bool> Handle(RemoveQuestionCommand request, CancellationToken cancellationToken)
        {
            await qusetionServices.Remove(request.QusetionId);

            return true;
        }
    }
}
