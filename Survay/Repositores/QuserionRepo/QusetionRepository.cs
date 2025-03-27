using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.Models.database;

namespace Survay.Repositores.QuserionRepo
{
    public class QusetionRepository : IQuestionRepository
    {
        db db ;

        public QusetionRepository(db db)
        {
            this.db = db;
        }

        public Task AddChoice(int QuestionId, Choice choice)
        {
            var Question = this.Get(QuestionId);
            Question.Choices.Add(choice);
            db.SaveChanges();
            return Task.CompletedTask;
            
        }

        public Question Get(int QuestionId)
        {
            return db.Questions.Include(e=>e.Choices).Where(e => e.QuestionID == QuestionId).FirstOrDefault();
        }

        public async Task Remove(Question question)
        {
            db.choses.RemoveRange(question.Choices);
            db.Questions.Remove(question);
            db.SaveChanges();
        }
        public async Task<List<Question>> GetSurveyQuestionsAsync(int surveyId)
        {
            return await db.Questions
                .Where(q => q.SurveyID == surveyId)
                .Include(q => q.Choices)
                .ToListAsync();
        }

        public Task Update(Question question)
        {
            db.Questions.Update(question);
            db.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
