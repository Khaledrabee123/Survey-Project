using Azure.Core;
using Microsoft.Extensions.Caching.Memory;
using Survay.DTOs;
using Survay.Models.database;
using Survay.Repositores.ChoiceRepo;
using Survay.Repositores.QuserionRepo;
using Survay.Repositores.ResponseRepo;
using Survay.Repositores.Surveyrepo;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.Services.SurvayServices
{
    public class SurveyService : ISurveyServices
    {
        private readonly ISurveyRepository _surveyRepository;
     
        IMemoryCache _cache;

        public SurveyService(ISurveyRepository surveyRepository,  IMemoryCache cache)
        {
            _surveyRepository = surveyRepository;
            _cache = cache;
        }

        public async Task<List<UserSurveysDTO>> GetUserSurveysAsync(string userId)
        {
            var surveys = await _surveyRepository.GetSurveyWithResponseByUserId(userId);

            return surveys.Select(s => new UserSurveysDTO
            {
                Id = s.SurveyID,
                Title = s.Title,
                Description = s.Description,
                TotalResponses = s.Responses.Count,
                Status = s.IsActive ? "active" : "notActive"
            }).ToList();
        }


        public async Task AddSurveyAsync(Survey survey)
        {
            await _surveyRepository.AddAsync(survey);
        }

        public async Task<bool> UpdateSurveyAsync(int surveyId, string field, string value)
        {
            var survey = await _surveyRepository.Get(surveyId);
            if (survey == null) return false;

            if (field == "Title") survey.Title = value;
            else if (field == "Description") survey.Description = value;

            await _surveyRepository.Update(survey);
            return true;
        }

        public async Task<bool> DeleteSurveyAsyn(int id)
        {
            var survey = await _surveyRepository.Get(id);
            if (survey == null) return false;

            _surveyRepository.Delete(survey);
            return true;
        }

        public async Task<surveyDTO> GetSurveyToEditAsync(int surveyId)
        {
            var survey = await _surveyRepository.GetSurveyWithQusetions(surveyId);

            if (survey == null) return null;

            return new surveyDTO
            {
                SurveyID = survey.SurveyID,
                UserID = survey.UserID,
                Title = survey.Title,
                Description = survey.Description,
                IsActive = survey.IsActive,
                CreatedAt = survey.CreatedAt,
                Questions = survey.Questions.Select(q => new QuestionDTO
                {
                    QuestionID = q.QuestionID,
                    QuestionNumber = q.QuestionNumber,
                    QuestionText = q.QuestionText,
                    QuestionType = q.QuestionType,
                    CreatedAt = q.CreatedAt,
                    choseDTOs = q.Choices.Select(c => new ChoiceDTO
                    {
                        Id = c.OptionID,
                        Text = c.OptionText
                    }).ToList()
                }).ToList()
            };

        }

        public async Task AddQuestion(int surveyId, Question question)
        {
            await _surveyRepository.AddQusetion(surveyId, question);

        }

        public async Task<List<object>> GetSurveyResultsAsync(int surveyId)
        {
            string cacheKey = $"SurveyResults_{surveyId}";

            if (_cache.TryGetValue(cacheKey, out List<object> cachedResults))
            {
                return cachedResults;
            }
            var result = await _surveyRepository.GetSurveyResultsAsync(surveyId);


            var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(10));
            _cache.Set(cacheKey, result.Cast<object>().ToList(), cacheEntryOptions);
            
            return result;
        }
    }
}
