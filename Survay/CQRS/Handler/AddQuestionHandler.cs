using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Command;
using Survay.Models.database;
using Survay.Repositores.QuserionRepo;
using Survay.Services.QusetionServices;
using Survay.Services.SurvayServices;
using static System.Net.Mime.MediaTypeNames;

namespace Survay.CQRS.Handler
{
    public class AddQuestionToSurveytHandler : IRequestHandler<AddQuestionToSurveyCommand, int>
    {
        ISurveyServices surveyServices ;
        IQusetionServices qusetionServices;
        public AddQuestionToSurveytHandler(ISurveyServices surveyServices, IQusetionServices qusetionServices)
        {
            this.surveyServices = surveyServices;
            this.qusetionServices = qusetionServices;
        }

        public async Task<int> Handle(AddQuestionToSurveyCommand request, CancellationToken cancellationToken)
        {
            var newQuestion = qusetionServices.make(request.Text);

            await surveyServices.AddQuestion(request.SurvayId, newQuestion);
            
            return newQuestion.QuestionID;
        }
    }
}
