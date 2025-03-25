using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Survay.CQRS.Command;
using Survay.Models.database;

namespace Survay.CQRS.Handler
{
    public class UpdateQuestionHandler : IRequestHandler<UpdateQuestionCommand, bool>
    {
        db db;

        public UpdateQuestionHandler(db db)
        {
            this.db = db;
        }

        public async Task<bool> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question =await db.Questions.FirstOrDefaultAsync(q => q.QuestionID == request.QuestionId);
            if (question == null)
            {
                return false;
            }

            if (request.field == "text")
            {
                question.QuestionText = request.Value;
            }
            else if (request.field == "type")
            {
                question.QuestionType = request.Value;
            }

            db.SaveChanges();

            return true;

        }
    }
}
