using Survay.DTOs;
using Survay.Models.database;

namespace Survay.Services.ResponsesServices
{
    public interface IReadResponceSerivce
    {
       

        public Task<int> TotalResponseForSurvey(int SurveyId);
        public Task<List<string>> GetTextResponsesAsync(int questionId);
        public Task<surveyDTO> GetSurveyForResponseAsync(int surveyId);

    }
}
