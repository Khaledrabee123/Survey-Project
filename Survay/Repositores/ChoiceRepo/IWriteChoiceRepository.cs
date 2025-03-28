using Survay.Models.database;

namespace Survay.Repositores.ChoiceRepo
{
    public interface IWriteChoiceRepository
    {
        public Task Add(Choice choicee);
        public Task Update(Choice choicee);
        public Task Delete(Choice choicee);
    }
}
