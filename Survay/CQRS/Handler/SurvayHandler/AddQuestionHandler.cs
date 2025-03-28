using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Command.SurvayCommnds;
using Survay.Models.database;
using Survay.Repositores.QuserionRepo;
using Survay.Services.QusetionServices;
using Survay.Services.SurvayServices;
using static System.Net.Mime.MediaTypeNames;

namespace Survay.CQRS.Handler.SurvayHandler
{
    public class AddQuestionToSurveytHandler : IRequestHandler<AddQuestionToSurveyCommand, int>
    {
        IWriteSurveyServices writeSurveyServices;
        IReadQusetionServices readQusetionServices;
        public AddQuestionToSurveytHandler(IReadQusetionServices readQusetionServices, IWriteSurveyServices writeSurveyServices)
        {
            this.writeSurveyServices = writeSurveyServices;
           this.readQusetionServices = readQusetionServices;
        }

        public async Task<int> Handle(AddQuestionToSurveyCommand request, CancellationToken cancellationToken)
        {
            var newQuestion = readQusetionServices.make(request.Text);

            await writeSurveyServices.AddQuestion(request.SurvayId, newQuestion);

            return newQuestion.QuestionID;
        }
    }
}
