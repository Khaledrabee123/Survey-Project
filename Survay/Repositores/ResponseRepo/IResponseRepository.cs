using Survay.Models.database;

namespace Survay.Repositores.ResponseRepo
{
    public interface IResponseRepository
    {
        public Task<int> TotalResponseForSurvey(int SurveyId);
        public Task<List<string>> GetTextResponsesAsync(int questionId);
        public Task add(Response response);
    }
}
