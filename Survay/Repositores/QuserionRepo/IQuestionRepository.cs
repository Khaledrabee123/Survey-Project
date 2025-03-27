using Survay.Models.database;

namespace Survay.Repositores.QuserionRepo
{
    public interface IQuestionRepository
    {
        public Task AddChoice(int QuestionId, Choice choice);
        public Question Get(int QuestionId);
        public Task Remove(Question question);
        public Task Update(Question question);
        public Task<List<Question>> GetSurveyQuestionsAsync(int surveyId);


    } 
}
