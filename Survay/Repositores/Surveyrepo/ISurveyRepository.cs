using Survay.Models.database;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.Repositores.Surveyrepo
{
    public interface ISurveyRepository
    {
        public Task AddAsync(Survey survey);
        public Task <Survey> GetSurveyWithQusetions(int surveyId);
        public Task <Survey> Get(int surveyId);
        public Task Update(Survey survey);
        public Task Delete(Survey survey);
        public Task<List<Survey>> GetSurveyWithResponseByUserId(String UserId);
        public Task AddQusetion(int SurveyId,Question question);

        public Task<int> GetTotalAnswersAsync(int questionId);
        public Task<List<object>> GetSurveyResultsAsync(int surveyId);


    }
}
