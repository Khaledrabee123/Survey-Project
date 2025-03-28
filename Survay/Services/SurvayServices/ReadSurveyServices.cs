using Microsoft.Extensions.Caching.Memory;
using Survay.DTOs;
using Survay.Models.database;
using Survay.Repositores.Surveyrepo;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.Services.SurvayServices
{
    public class ReadSurveyServices : IReadSurveyServices
    {
        private readonly IReadSurveyRepository _readsurveyRepository;
        IMemoryCache _cache;

        public ReadSurveyServices(IReadSurveyRepository _rsurveyRepository, IMemoryCache cache)
        {
            _readsurveyRepository = _rsurveyRepository;
            _cache = cache;
        }

        public async Task<List<UserSurveysDTO>> GetUserSurveysAsync(string userId)
        {
            var surveys = await _readsurveyRepository.GetSurveyWithResponseByUserId(userId);

            return surveys.Select(s => new UserSurveysDTO
            {
                Id = s.SurveyID,
                Title = s.Title,
                Description = s.Description,
                TotalResponses = s.Responses.Count,
                Status = s.IsActive ? "active" : "notActive"
            }).ToList();
        }

        public async Task<surveyDTO> GetSurveyToEditAsync(int surveyId)
        {
            var survey = await _readsurveyRepository.GetSurveyWithQusetions(surveyId);

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
            public async Task<List<object>> GetSurveyResultsAsync(int surveyId)
            {
                string cacheKey = $"SurveyResults_{surveyId}";

                if (_cache.TryGetValue(cacheKey, out List<object> cachedResults))
                {
                    return cachedResults;
                }
                var result = await _readsurveyRepository.GetSurveyResultsAsync(surveyId);


                var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(10));
                _cache.Set(cacheKey, result.Cast<object>().ToList(), cacheEntryOptions);

                return result;
            }
        public async Task<Survey?> GetSurveyWithQusetions(int surveyId)
        {
            return await _readsurveyRepository.GetSurveyWithQusetions(surveyId);

        }

        public async Task<Survey> Get(int surveyId)
        {
        return await  _readsurveyRepository.Get(surveyId);
        }
    }
}
