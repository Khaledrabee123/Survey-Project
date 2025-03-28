using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Query.ResponseQuerys;
using Survay.DTOs;
using Survay.Models.database;
using Survay.Services.ResponsesServices;

namespace Survay.CQRS.Handler.ResponseHandler
{
    public class ResponseToSurveyHandler : IRequestHandler<ResponseToSurveyQuery, surveyDTO>
    {
        IReadResponceSerivce responceSerivce;

        public ResponseToSurveyHandler(IReadResponceSerivce responceSerivce)
        {
            this.responceSerivce = responceSerivce;
        }



        public async Task<surveyDTO> Handle(ResponseToSurveyQuery request, CancellationToken cancellationToken)
        {

            return await responceSerivce.GetSurveyForResponseAsync(request.SurveyId);
        }
    }
}
