using Survay.Models.database;

namespace Survay.Repositores.ResponseRepo
{
    public interface IReadResponseRepository
    {
        public Task<int> TotalResponseForSurvey(int SurveyId);
        public Task<List<string>> GetTextResponsesAsync(int questionId);
    }
}
