using Survay.Models.database;

namespace Survay.Services.QusetionServices
{
    public interface IWriteQusetionServices
    {
        public Task AddChoice(int QuestionId, Choice choice);
        public Task Remove(int id);
        public Task Update(int QusetionId, String field, String Value);
    }
}
