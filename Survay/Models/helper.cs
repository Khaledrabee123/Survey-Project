using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using Survay.Models.database;
using Survay.Models.DTO;
using WebApplication3.Models.WebApplication3.Models;

namespace WebApplication3.Models
{
    public class helper
    {
        private readonly IMemoryCache _cache;
        public static Response MapToResponse(ResponceDTO dto)
        {
            return new Response
            {
                ResponseID = dto.ResponseID,
                SubmittedAt = dto.SubmittedAt,
                SurveyID = dto.SurveyID,
                UserID = (dto.UserID == null ? "e66be1e3-8de8-4db1-b67c-b461e38edea6" : dto.UserID),
                Answers = dto.Answers.Select(a => new Answer
                {
                    AnswerID = a.AnswerID,
                    AnswerText = a.AnswerText,
                    ResponseID = a.ResponseID,
                    QuestionID = a.QuestionID,
                    OptionID = a.OptionID
                }).ToList()
            };
        }
        public static Servay ConvertToSurvey(servayDTO surveyDto)
        {
            return new Servay
            {
                SurveyID = surveyDto.SurveyID,
                Title = surveyDto.Title,
                Description = surveyDto.Description,
                IsActive = surveyDto.IsActive,
                CreatedAt = surveyDto.CreatedAt,
                Questions = surveyDto.Questions.Select(q => new Question
                {
                    QuestionNumber = q.QuestionNumber,
                    QuestionText = q.QuestionText,
                    QuestionType = q.QuestionType,
                    CreatedAt = q.CreatedAt,
                    Choices = (q.choseDTOs ?? new List<ChoiceDTO>())
                              .Select(c => new Choice
                              {
                                  OptionText = c.Text ?? "Default Choice"
                              }).ToList()
                }).ToList()
            };


        }
    }
}
