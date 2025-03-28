using System.Linq.Expressions;
using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Survay.Models.database;
using Survay.Services.SurvayServices;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.Repositores.Surveyrepo
{
    public class WriteSurveyRepository : IWriteSurveyRepository
    {
        db db;
        IReadSurveyServices readSurveyServices;
        public WriteSurveyRepository(db db, IReadSurveyServices readSurveyServices)
        {

            this.db = db;
            this.readSurveyServices = readSurveyServices;
        }

        public async Task AddAsync(Survey survay)
        {
           await db.Surveys.AddAsync(survay);
            db.SaveChanges();
        }

        public async Task AddQusetion(int SurveyId, Question question)
        {
            var s =await readSurveyServices.GetSurveyWithQusetions(SurveyId);
            s.Questions.Add(question);
            db.SaveChanges();

        }

        public async Task Delete(Survey survey)
        {

            db.choses.RemoveRange(survey.Questions.SelectMany(q => q.Choices));
            db.Questions.RemoveRange(survey.Questions);
            db.Responses.RemoveRange(survey.Responses);
            db.Surveys.Remove(survey);

            db.SaveChanges();
            return;
        }

      

     

     

        public async Task Update(Survey survey)
        {
           db.Update(survey);
           await db.SaveChangesAsync ();

        }


     

    }
}
