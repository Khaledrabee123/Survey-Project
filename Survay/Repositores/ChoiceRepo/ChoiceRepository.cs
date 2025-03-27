using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Survay.Models.database;

namespace Survay.Repositores.ChoiceRepo
{
    public class ChoiceRepository : IChoiceRepository
    {
        db db;

        public ChoiceRepository(db db)
        {
            this.db = db;
        }

        public Task Add(Choice choicee)
        {
            db.choses.Add(choicee);
            db.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Delete(Choice choicee)
        {
            db.choses.Remove(choicee);
            db.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<Choice> Get(int choiceId)
        {
          return await db.choses.FirstOrDefaultAsync(c => c.OptionID == choiceId);
        }

        public bool IsChoiceHasAnswersQuery(int id)
        {
            return db.Answers.Any(a => a.OptionID == id);
        }
        public async Task<int> GetChoiceAnswersCountAsync(int choiceId)
        {
            return await db.Answers.CountAsync(a => a.OptionID == choiceId);
        }

        public async Task<bool> IsMCQAsync(int questionId)
        {
            return await db.choses.AnyAsync(c => c.QuestionID == questionId);
        }
        public Task Update(Choice choicee)
        {
            db.choses.Update(choicee);
            db.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
