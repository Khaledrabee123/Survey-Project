using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Command.SurvayCommnds;
using Survay.Models.database;
using Survay.Services.SurvayServices;

namespace Survay.CQRS.Handler.SurvayHandler
{
    public class DeleteSurveyHandler : IRequestHandler<DeleteSurveycommand>
    {

        IWriteSurveyServices writeSurveyServices;
        public DeleteSurveyHandler(IWriteSurveyServices writeSurveyServices)
        {
            this.writeSurveyServices = writeSurveyServices;
        }



        public Task Handle(DeleteSurveycommand request, CancellationToken cancellationToken)
        {
            writeSurveyServices.DeleteSurveyAsyn(request.SurveyId);
            return Task.CompletedTask;
        }
    }
}
