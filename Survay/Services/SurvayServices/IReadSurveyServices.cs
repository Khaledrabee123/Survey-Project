using Survay.DTOs;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.Services.SurvayServices
{
    public interface IReadSurveyServices
    {
        public Task<Survey> Get(int surveyId);
        public Task<List<UserSurveysDTO>> GetUserSurveysAsync(string userId);
        public Task<List<object>> GetSurveyResultsAsync(int surveyId);
        public Task<surveyDTO> GetSurveyToEditAsync(int surveyId);
        public Task<Survey> GetSurveyWithQusetions(int surveyId);

    }
}
