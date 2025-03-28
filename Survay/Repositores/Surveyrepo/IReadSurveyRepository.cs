using WebApplication3.Models.WebApplication3.Models;

namespace Survay.Repositores.Surveyrepo
{
    public interface IReadSurveyRepository
    {
        public Task<Survey> Get(int surveyId);
        public Task<Survey> GetSurveyWithQusetions(int surveyId);
        public Task<List<Survey>> GetSurveyWithResponseByUserId(String UserId);
        public Task<int> GetTotalAnswersAsync(int questionId);
        public Task<List<object>> GetSurveyResultsAsync(int surveyId);
    }
}
