using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Survay.CQRS.Command;
using Survay.Models.database;
using Survay.Services.QusetionServices;

namespace Survay.CQRS.Handler
{
    public class UpdateQuestionHandler : IRequestHandler<UpdateQuestionCommand, bool>
    {

        IQusetionServices qusetionServices;

        public UpdateQuestionHandler(IQusetionServices qusetionServices)
        {
            this.qusetionServices = qusetionServices;
        }

       
        public async Task<bool> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {

            await qusetionServices.Update(request.QuestionId, request.field, request.Value);
            return true;

        }
    }
}
