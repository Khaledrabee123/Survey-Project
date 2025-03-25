using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Command;
using Survay.Models.database;

namespace Survay.CQRS.Handler
{
    public class RemoveQuestionHandler : IRequestHandler<RemoveQuestionCommand, bool>
    {
        db db;

        public RemoveQuestionHandler(db db)
        {
            this.db = db;
        }

        public async Task<bool> Handle(RemoveQuestionCommand request, CancellationToken cancellationToken)
        {
            var question =await db.Questions.Include(q => q.Choices).FirstOrDefaultAsync(q => q.QuestionID == request.QusetionId);
            if (question == null)
            {
                return false;
            }

            db.choses.RemoveRange(question.Choices);
            db.Questions.Remove(question);
            db.SaveChanges();

            return true;
        }
    }
}
