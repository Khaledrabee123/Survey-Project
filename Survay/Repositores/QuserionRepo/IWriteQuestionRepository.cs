using Survay.Models.database;

namespace Survay.Repositores.QuserionRepo
{
    public interface IWriteQuestionRepository
    {
        public Task AddChoice(int QuestionId, Choice choice);
        public Task Remove(Question question);
        public Task Update(Question question);



    } 
}
