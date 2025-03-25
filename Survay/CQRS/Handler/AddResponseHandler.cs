using MediatR;
using Survay.CQRS.Command;
using Survay.Models.database;
using Survay.Models.DTO;

namespace Survay.CQRS.Handler
{
    public class AddResponseHandler : IRequestHandler<AddResponseCommand>
    {
        db db;

        public AddResponseHandler(db db)
        {
            this.db = db;
        }

        public Task Handle(AddResponseCommand request, CancellationToken cancellationToken)
        {
            var ResponseList = db.Surveys.FirstOrDefault(r => r.SurveyID == request.response.SurveyID);
            ResponseList.Responses.Add(request.response);
            db.Update(ResponseList);
            db.SaveChanges();
            return Task.CompletedTask; 
        }
    }
}
