using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Command;
using Survay.Models.database;

namespace Survay.CQRS.Handler
{
    public class DeleteSurvayHandler : IRequestHandler<DeleteSurvaycommand>
    {
        db db;

        public DeleteSurvayHandler(db db)
        {
            this.db = db;
        }

        public Task Handle(DeleteSurvaycommand request, CancellationToken cancellationToken)
        {
                var survey = db.Surveys
                    .Include(s => s.Questions)
                    .ThenInclude(q => q.Choices)
                    .Include(s => s.Responses)
                    .FirstOrDefault(s => s.SurveyID == request.SurveyId);


                    // delete ForInKyes
                    db.choses.RemoveRange(survey.Questions.SelectMany(q => q.Choices));
                    db.Questions.RemoveRange(survey.Questions);
                    db.Responses.RemoveRange(survey.Responses);
                    db.Surveys.Remove(survey);

            db.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
