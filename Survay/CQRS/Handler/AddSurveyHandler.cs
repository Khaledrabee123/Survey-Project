using MediatR;
using Survay.CQRS.Command;
using Survay.Models.database;

namespace Survay.CQRS.Handler
{
    public class AddSurveyHandler : IRequestHandler<AddSurveyCommand>
    {
        db db;

        public AddSurveyHandler(db db)
        {
            this.db = db;
        }

        public Task Handle(AddSurveyCommand request, CancellationToken cancellationToken)
        {
            db.Surveys.Add(request.Survay);
            db.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
