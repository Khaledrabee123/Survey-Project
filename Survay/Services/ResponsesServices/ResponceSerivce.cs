using Survay.DTOs;
using Survay.Models.database;
using Survay.Repositores.ResponseRepo;
using Survay.Repositores.Surveyrepo;
using Survay.Services.SurvayServices;

namespace Survay.Services.ResponsesServices
{
    public class ResponceSerivce : IResponceSerivce
    {
        IResponseRepository responseRepository;
        ISurveyRepository surveyRepository;

        public ResponceSerivce(IResponseRepository responseRepository, ISurveyRepository surveyRepository)
        {
            this.responseRepository = responseRepository;
            this.surveyRepository = surveyRepository;
        }

        public Task add(Response response)
        {
            responseRepository.add(response);
            return Task.CompletedTask;
        }

        public Task<List<string>> GetTextResponsesAsync(int questionId)
        {
          return responseRepository.GetTextResponsesAsync(questionId);  
        }

        public Task<int> TotalResponseForSurvey(int SurveyId)
        {
          return responseRepository.TotalResponseForSurvey(SurveyId);
        }
        public async Task<surveyDTO> GetSurveyForResponseAsync(int surveyId)
        {
            var survey = await surveyRepository.GetSurveyWithQusetions(surveyId);

            if (survey == null)
                return null;

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
    }
}
