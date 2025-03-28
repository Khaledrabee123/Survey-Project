using Microsoft.EntityFrameworkCore;
using Survay.Models.database;

namespace Survay.Repositores.QuserionRepo
{
    public class ReadQusestionRepository : IReadQusetionRepository
    {
        db db;

        public ReadQusestionRepository(db db)
        {
            this.db = db;
        }

        public async Task<List<Question>> GetSurveyQuestionsAsync(int surveyId)
        {
            return await db.Questions
                .Where(q => q.SurveyID == surveyId)
                .Include(q => q.Choices)
                .ToListAsync();
        }
        public Question Get(int QuestionId)
        {
            return db.Questions.Include(e => e.Choices).Where(e => e.QuestionID == QuestionId).FirstOrDefault();
        }
    }
    }

