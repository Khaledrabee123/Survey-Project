using Survay.DTOs;
using Survay.Models.database;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.Services.SurvayServices
{
    public interface ISurveyServices
    {
        public Task<List<UserSurveysDTO>> GetUserSurveysAsync(string userId);

        public Task AddSurveyAsync(Survey survey);
        public Task<bool> UpdateSurveyAsync(int surveyId, string field, string value);
        public Task<bool> DeleteSurveyAsyn(int id);
        public Task<surveyDTO> GetSurveyToEditAsync(int surveyId);
        public Task AddQuestion(int surveyId, Question question);
        public Task<List<object>> GetSurveyResultsAsync(int surveyId);

    }
}
