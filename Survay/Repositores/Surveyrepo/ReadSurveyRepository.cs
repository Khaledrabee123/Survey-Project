using Microsoft.EntityFrameworkCore;
using Survay.Models.database;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.Repositores.Surveyrepo
{
    public class ReadSurveyRepository : IReadSurveyRepository
    {
        db db;

        public ReadSurveyRepository(db db)
        {
            this.db = db;
        }

        public async Task<Survey> Get(int surveyId)
        {
            var survey = db.Surveys
            .Include(s => s.Questions)
            .ThenInclude(q => q.Choices)
            .Include(s => s.Responses)
            .FirstOrDefault(s => s.SurveyID == surveyId);

            return survey;
        }

        public async Task<Survey?> GetSurveyWithQusetions(int surveyId)
        {
            return await db.Surveys
                        .Where(s => s.SurveyID == surveyId)
                        .Include(s => s.Questions)
                        .ThenInclude(q => q.Choices)
                        .FirstOrDefaultAsync();

        }


        public async Task<List<Survey>> GetSurveyWithResponseByUserId(string UserId)
        {
            return await db.Surveys
                           .Include(s => s.Responses)
                           .Where(s => s.UserID == UserId)
                           .ToListAsync();
        }


        public async Task<List<Question>> GetSurveyQuestionsAsync(int surveyId)
        {
            return await db.Questions
                .Where(q => q.SurveyID == surveyId)
                .Include(q => q.Choices)
                .ToListAsync();
        }

        public async Task<int> GetTotalAnswersAsync(int questionId)
        {
            return await db.Answers.CountAsync(a => a.QuestionID == questionId);
        }



        public async Task<List<object>> GetSurveyResultsAsync(int surveyId)
        {

            var results = await db.Questions
                              .Where(q => q.SurveyID == surveyId)
                              .Select(q => new
                              {
                                  question = q.QuestionText,
                                  isMCQ = db.choses.Any(c => c.QuestionID == q.QuestionID),
                                  choices = db.choses
                                      .Where(c => c.QuestionID == q.QuestionID)
                                      .Select(c => new
                                      {
                                          choice = c.OptionText,
                                          count = db.Answers.Count(a => a.QuestionID == q.QuestionID) > 0
                                              ? (float)db.Answers.Count(a => a.OptionID == c.OptionID) / db.Answers.Count(a => a.QuestionID == q.QuestionID) * 100
                                              : 0
                                      }).ToList(),
                                  response = db.Answers
                                      .Where(a => a.QuestionID == q.QuestionID && a.OptionID == null && a.AnswerText != null)
                                      .Select(a => a.AnswerText)
                                      .ToList()
                              }).ToListAsync();



            return results.Cast<object>().ToList();

        }
    }
}
