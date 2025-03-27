using Survay.Models.database;

namespace Survay.Services.ChoiceServices
{
    public interface IChoiceServices
    {
        public Choice MakeChoice(String Text);
        public Task Add(Choice Choice);   
        public Task Remove(Choice Choice);
        public Task Update(int id, String Text);
        public Task<Choice> Get(int id);
        public bool IsChoiceHasAnswersQuery(int id);
        public Task<int> GetChoiceAnswersCountAsync(int choiceId);
        public Task<bool> IsMCQAsync(int questionId);
    }
}
