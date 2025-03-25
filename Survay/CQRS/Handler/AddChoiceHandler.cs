using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Command;
using Survay.Models.database;
using static System.Net.Mime.MediaTypeNames;

namespace Survay.CQRS.Handler
{
    public class AddChoiceHandler : IRequestHandler<AddChoiceCommand, int>
    {
        db db;

        public AddChoiceHandler(db db)
        {
            this.db = db;
        }

        public async Task<int> Handle(AddChoiceCommand request, CancellationToken cancellationToken)
        {
            var question =await db.Questions.Include(q => q.Choices).FirstOrDefaultAsync(q => q.QuestionID == request.questionId);

            var newChoice = new Choice { OptionText = request.text };

            question.Choices.Add(newChoice);

            db.SaveChanges();

            return newChoice.OptionID;





        }
    }
}
