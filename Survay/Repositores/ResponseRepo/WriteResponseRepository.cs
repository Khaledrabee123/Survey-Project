using Survay.Models.database;

namespace Survay.Repositores.ResponseRepo
{
    public class WriteResponseRepository : IWriteResponseRepository
    {
        db db;

        public WriteResponseRepository(db db)
        {
            this.db = db;
        }

        public Task add(Response response)
        {
            var survey = db.Surveys.FirstOrDefault(r => r.SurveyID == response.SurveyID);
            survey.Responses.Add(response);
            db.Update(survey);
            db.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
