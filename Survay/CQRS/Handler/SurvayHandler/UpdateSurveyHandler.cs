using MediatR;
using Newtonsoft.Json.Linq;
using Survay.CQRS.Command.SurvayCommnds;
using Survay.Models.database;
using Survay.Services.SurvayServices;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.CQRS.Handler.SurvayHandler
{
    public class UpdateSurveyHandler : IRequestHandler<UpdateSurveyCommand, bool>
    {

        IWriteSurveyServices writeSurveyServices;
        public UpdateSurveyHandler(IWriteSurveyServices writeSurveyServices)
        {
            this.writeSurveyServices = writeSurveyServices;
        }

        public async Task<bool> Handle(UpdateSurveyCommand request, CancellationToken cancellationToken)
        {

            return await writeSurveyServices.UpdateSurveyAsync(request.SurveyId, request.field, request.Value);

        }
    }
}
