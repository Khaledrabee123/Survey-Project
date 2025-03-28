using Survay.Models.database;

namespace Survay.Services.ChoiceServices
{
    public interface IReadChoiceServices
    {
        public Choice MakeChoice(String Text);
        public Task<Choice> Get(int id);
        public bool IsChoiceHasAnswersQuery(int id);
        public Task<int> GetChoiceAnswersCountAsync(int choiceId);
        public Task<bool> IsMCQAsync(int questionId);
    }
}
