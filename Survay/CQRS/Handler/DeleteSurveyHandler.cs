using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Command;
using Survay.Models.database;
using Survay.Services.SurvayServices;

namespace Survay.CQRS.Handler
{
    public class DeleteSurveyHandler : IRequestHandler<DeleteSurveycommand>
    {
       ISurveyServices surveyServices;

        public DeleteSurveyHandler(ISurveyServices surveyServices)
        {
            this.surveyServices = surveyServices;
        }

        

        public Task Handle(DeleteSurveycommand request, CancellationToken cancellationToken)
        {
             surveyServices.DeleteSurveyAsyn(request.SurveyId);
            return Task.CompletedTask;
        }
    }
}
