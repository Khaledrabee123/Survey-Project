using MediatR;
using Survay.CQRS.Command.SurvayCommnds;
using Survay.Models.database;
using Survay.Services.SurvayServices;

namespace Survay.CQRS.Handler.SurvayHandler
{
    public class AddSurveyHandler : IRequestHandler<AddSurveyCommand>
    {

        IWriteSurveyServices writeSurveyServices;
        public AddSurveyHandler(IWriteSurveyServices writeSurveyServices)
        {
            this.writeSurveyServices = writeSurveyServices;
        }

        public Task Handle(AddSurveyCommand request, CancellationToken cancellationToken)
        {
            return writeSurveyServices.AddSurveyAsync(request.Survay);

        }
    }
}
