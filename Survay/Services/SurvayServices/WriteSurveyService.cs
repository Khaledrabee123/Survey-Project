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
    public class WriteSurveyService : IWriteSurveyServices
    {
        private readonly IWriteSurveyRepository _surveyRepository;
        IReadSurveyServices _readSurveyServices;
     

        public WriteSurveyService(IWriteSurveyRepository surveyRepository, IReadSurveyServices readSurveyServices)
        {
            _surveyRepository = surveyRepository;
            _readSurveyServices = readSurveyServices;
        }
        public async Task AddQuestion(int surveyId, Question question)
        {
            await _surveyRepository.AddQusetion(surveyId, question);

        }
      


        public async Task AddSurveyAsync(Survey survey)
        {
            await _surveyRepository.AddAsync(survey);
        }

        public async Task<bool> UpdateSurveyAsync(int surveyId, string field, string value)
        {
            var survey = await _readSurveyServices.Get(surveyId);
            if (survey == null) return false;

            if (field == "Title") survey.Title = value;
            else if (field == "Description") survey.Description = value;

            await _surveyRepository.Update(survey);
            return true;
        }

        public async Task<bool> DeleteSurveyAsyn(int id)
        {
            var survey = await _readSurveyServices.Get(id);
            if (survey == null) return false;

            _surveyRepository.Delete(survey);
            return true;
        }

      

        }

    

     
    }
