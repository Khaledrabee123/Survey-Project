using Survay.Models.database;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.Repositores.Surveyrepo
{
    public interface IWriteSurveyRepository
    {
        public Task AddAsync(Survey survey);
        public Task Update(Survey survey);
        public Task Delete(Survey survey);
        public Task AddQusetion(int SurveyId,Question question);

       


    }
}
