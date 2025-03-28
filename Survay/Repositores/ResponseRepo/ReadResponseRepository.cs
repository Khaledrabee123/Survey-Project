
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Survay.Models.database;

namespace Survay.Repositores.ResponseRepo
{
    public class ReadResponseRepository : IReadResponseRepository
    {
        db db;

        public ReadResponseRepository(db db)
        {
            this.db = db;
        }

        public async Task<int> TotalResponseForSurvey(int SurveyId)
        {
           return await db.Responses.CountAsync(e => e.SurveyID == SurveyId);
        }
        public async Task<List<string>> GetTextResponsesAsync(int questionId)
        {
            return await db.Answers
                .Where(a => a.QuestionID == questionId && a.OptionID == null && a.AnswerText != null)
                .Select(a => a.AnswerText)
                .ToListAsync();
        }

    }
}
