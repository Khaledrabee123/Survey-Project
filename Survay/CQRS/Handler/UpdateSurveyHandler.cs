using MediatR;
using Newtonsoft.Json.Linq;
using Survay.CQRS.Command;
using Survay.Models.database;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.CQRS.Handler
{
    public class UpdateSurveyHandler : IRequestHandler<UpdateSurveyCommand, bool>
    {
        db db;

        public UpdateSurveyHandler(db db)
        {
            this.db = db;
        }

        public async Task<bool> Handle(UpdateSurveyCommand request, CancellationToken cancellationToken)
        {
             var survey = await db.Surveys.FindAsync(request.SurveyId);
            if (survey == null)
                return false;

            if (request.field == "Title")
                survey.Title = request.Value;
            else if (request.field == "Description")
                survey.Description = request.Value;
            else
                return false;

            db.SaveChanges();

            return true;
            
        }
    }
}
