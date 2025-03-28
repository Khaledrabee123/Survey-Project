using Survay.Models.database;

namespace Survay.Repositores.ChoiceRepo
{
    public class WrtieChoiceRepository:IWriteChoiceRepository
    {
        db db;

        public WrtieChoiceRepository(db db)
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
        public Task Update(Choice choicee)
        {
            db.choses.Update(choicee);
            db.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
