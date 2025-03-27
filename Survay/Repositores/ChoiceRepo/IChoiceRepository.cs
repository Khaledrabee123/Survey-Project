using Survay.Models.database;

namespace Survay.Repositores.ChoiceRepo
{
    public interface IChoiceRepository
    {
        public Task Add(Choice choicee);
        public Task Update(Choice choicee);
        public Task Delete(Choice choicee);
        public Task<Choice> Get(int id);
        public bool IsChoiceHasAnswersQuery(int id);
        public Task<int> GetChoiceAnswersCountAsync(int choiceId);
        public Task<bool> IsMCQAsync(int questionId);
    }
}
