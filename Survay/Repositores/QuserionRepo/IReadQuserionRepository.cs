using Survay.Models.database;

namespace Survay.Repositores.QuserionRepo
{
    public interface IReadQusetionRepository
    {
        public Question Get(int QuestionId);
        public Task<List<Question>> GetSurveyQuestionsAsync(int surveyId);
    }
}
