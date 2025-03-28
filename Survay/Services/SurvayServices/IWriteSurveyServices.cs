using Survay.DTOs;
using Survay.Models.database;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.Services.SurvayServices
{
    public interface IWriteSurveyServices
    {
       

        public Task AddSurveyAsync(Survey survey);
        public Task<bool> UpdateSurveyAsync(int surveyId, string field, string value);
        public Task<bool> DeleteSurveyAsyn(int id);
        public Task AddQuestion(int surveyId, Question question);

    }
}
