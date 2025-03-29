using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Survay.Models.database;

namespace Survay.Repositores.ChoiceRepo
{
    public class ReadChoiceRepository : IReadChoiceRepository
    {
        db db;

        public ReadChoiceRepository(db db)
        {
            this.db = db;
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
            var s = (db.Questions.Where(e => e.QuestionID == questionId).FirstOrDefault());
            return ( s.QuestionType =="MCQ");
        }
        public Task Update(Choice choicee)
        {
            db.choses.Update(choicee);
            db.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
