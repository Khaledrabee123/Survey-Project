using MediatR;
using Survay.CQRS.Query;
using Survay.Models.database;

namespace Survay.CQRS.Handler
{
    public class IsChoiceHasAnswersHandler : IRequestHandler<IsChoiceHasAnswersQuery, bool>
    {
        db db;

        public IsChoiceHasAnswersHandler(db db)
        {
            this.db = db;
        }

        public async Task<bool> Handle(IsChoiceHasAnswersQuery request, CancellationToken cancellationToken)
        {
           return  db.Answers.Any(a => a.OptionID == request.choiceId);
            
        }
    }
}
