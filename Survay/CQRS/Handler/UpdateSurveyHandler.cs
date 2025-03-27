using MediatR;
using Newtonsoft.Json.Linq;
using Survay.CQRS.Command;
using Survay.Models.database;
using Survay.Services.SurvayServices;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.CQRS.Handler
{
    public class UpdateSurveyHandler : IRequestHandler<UpdateSurveyCommand, bool>
    {
       
        ISurveyServices surveyServices;
        public UpdateSurveyHandler(ISurveyServices surveyServices)
        {
            this.surveyServices = surveyServices;
        }

        public async Task<bool> Handle(UpdateSurveyCommand request, CancellationToken cancellationToken)
        {

            return await surveyServices.UpdateSurveyAsync(request.SurveyId, request.field, request.Value);

        }
    }
}
