using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Survay.CQRS.Query;
using Survay.DTOs;
using Survay.Models.database;
using Survay.Services.SurvayServices;

namespace Survay.CQRS.Handler
{
    public class GetSurveyToEditHandler : IRequestHandler<GetSurveyToEditQuery, surveyDTO>
    {
        ISurveyServices surveyServices;

        public GetSurveyToEditHandler(ISurveyServices surveyServices)
        {
            this.surveyServices = surveyServices;
        }

        public async Task<surveyDTO> Handle(GetSurveyToEditQuery request, CancellationToken cancellationToken)
        {



            return await surveyServices.GetSurveyToEditAsync(request.SurvayId);
            
        }
       
    }
}
