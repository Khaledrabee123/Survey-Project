using Survay.Models.database;

namespace Survay.Services.QusetionServices
{
    public interface IQusetionServices
    {
        public Task AddChoice(int QuestionId, Choice choice);
        public Question Get(int QuestionId);
        public Question make(String Text);
        public Task Remove(int id);
        public Task Update(int QusetionId, String field, String Value);
    }
}
