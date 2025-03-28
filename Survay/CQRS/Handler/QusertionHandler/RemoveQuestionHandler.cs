using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Command.QuserionCommands;
using Survay.Models.database;
using Survay.Services.QusetionServices;

namespace Survay.CQRS.Handler.QusertionHandler
{
    public class RemoveQuestionHandler : IRequestHandler<RemoveQuestionCommand, bool>
    {
        IWriteQusetionServices writeQusetionServices;

        public RemoveQuestionHandler(IWriteQusetionServices writeQusetionServices)
        {
            this.writeQusetionServices = writeQusetionServices;
        }



        public async Task<bool> Handle(RemoveQuestionCommand request, CancellationToken cancellationToken)
        {
            await writeQusetionServices.Remove(request.QusetionId);

            return true;
        }
    }
}
