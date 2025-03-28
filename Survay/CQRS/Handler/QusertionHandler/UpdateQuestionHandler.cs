using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Survay.CQRS.Command.QuserionCommands;
using Survay.Models.database;
using Survay.Services.QusetionServices;

namespace Survay.CQRS.Handler.QusertionHandler
{
    public class UpdateQuestionHandler : IRequestHandler<UpdateQuestionCommand, bool>
    {

        IWriteQusetionServices writeQusetionServices;

        public UpdateQuestionHandler(IWriteQusetionServices qusetionServices)
        {
            writeQusetionServices = qusetionServices;
        }


        public async Task<bool> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {

            await writeQusetionServices.Update(request.QuestionId, request.field, request.Value);
            return true;

        }
    }
}
