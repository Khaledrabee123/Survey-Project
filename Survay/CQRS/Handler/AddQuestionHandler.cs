using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Command;
using Survay.Models.database;
using static System.Net.Mime.MediaTypeNames;

namespace Survay.CQRS.Handler
{
    public class AddQuestionHandler : IRequestHandler<AddQuestionCommand, int>
    {
        db db ;

        public AddQuestionHandler(db db)
        {
            this.db = db;
        }

        public async Task<int> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {
            var newQuestion = new Question
            {
                QuestionText = request.Text,
                QuestionType = "MCQ", // Default type
                Choices = new List<Choice>() // Empty choices initially
            };
            var su = await db.Surveys.Include(e => e.Questions).FirstOrDefaultAsync(e => e.SurveyID == request.SurvayId);
            su.Questions.Add(newQuestion);
            db.SaveChanges();
            return newQuestion.QuestionID;
        }
    }
}
