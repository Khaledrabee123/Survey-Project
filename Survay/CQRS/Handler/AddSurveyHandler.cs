using MediatR;
using Survay.CQRS.Command;
using Survay.Models.database;
using Survay.Services.SurvayServices;

namespace Survay.CQRS.Handler
{
    public class AddSurveyHandler : IRequestHandler<AddSurveyCommand>
    {

        ISurveyServices surveyServices;
        public AddSurveyHandler(ISurveyServices surveyServices)
        {
            this.surveyServices = surveyServices;
        }

        public Task Handle(AddSurveyCommand request, CancellationToken cancellationToken)
        {
           return surveyServices.AddSurveyAsync(request.Survay);
            
        }
    }
}
