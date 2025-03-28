using Survay.Models.database;

namespace Survay.Repositores.ChoiceRepo
{
    public interface IReadChoiceRepository
    {

        public Task<Choice> Get(int id);
        public bool IsChoiceHasAnswersQuery(int id);
        public Task<int> GetChoiceAnswersCountAsync(int choiceId);
        public Task<bool> IsMCQAsync(int questionId);
    }
}
