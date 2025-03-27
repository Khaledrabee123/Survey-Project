using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Query;
using Survay.DTOs;
using Survay.Models.database;
using Survay.Services.ResponsesServices;

namespace Survay.CQRS.Handler
{
    public class ResponseToSurveyHandler : IRequestHandler<ResponseToSurveyQuery, surveyDTO>
    {
        IResponceSerivce responceSerivce;

        public ResponseToSurveyHandler(IResponceSerivce responceSerivce)
        {
            this.responceSerivce = responceSerivce;
        }

     

        public async Task<surveyDTO> Handle(ResponseToSurveyQuery request, CancellationToken cancellationToken)
        {

            return await responceSerivce.GetSurveyForResponseAsync(request.SurveyId);
        }
    }
}
