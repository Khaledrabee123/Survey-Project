using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.Models.database;
using Survay.Services.QusetionServices;

namespace Survay.Repositores.QuserionRepo
{
    public class WriteQusetionRepository : IWriteQuestionRepository
    {
        db db ;
        IReadQusetionServices readQusetionServices;


        public WriteQusetionRepository(db db, IReadQusetionServices readQusetionServices)
        {
            this.db = db;
            this.readQusetionServices = readQusetionServices;
        }

        public Task AddChoice(int QuestionId, Choice choice)
        {
            var Question = readQusetionServices.Get(QuestionId);
            Question.Choices.Add(choice);
            db.SaveChanges();
            return Task.CompletedTask;
            
        }

    

        public async Task Remove(Question question)
        {
            db.choses.RemoveRange(question.Choices);
            db.Questions.Remove(question);
            db.SaveChanges();
        }
     

        public Task Update(Question question)
        {
            db.Questions.Update(question);
            db.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
