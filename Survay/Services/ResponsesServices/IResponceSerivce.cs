using Survay.DTOs;
using Survay.Models.database;

namespace Survay.Services.ResponsesServices
{
    public interface IResponceSerivce
    {
        public Task<int> TotalResponseForSurvey(int SurveyId);
        public Task<List<string>> GetTextResponsesAsync(int questionId);
        public Task add(Response response);
        public Task<surveyDTO> GetSurveyForResponseAsync(int surveyId);

    }
}
