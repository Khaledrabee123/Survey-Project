using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Query.ResponseQuerys;
using Survay.Models.database;
using Survay.Services.ResponsesServices;

namespace Survay.CQRS.Handler.ResponseHandler
{
    public class TotalResponseForSurveyHandler : IRequestHandler<TotalResponseForSurveyQuery, int>
    {
        IReadResponceSerivce responseSuervice;

        public TotalResponseForSurveyHandler(IReadResponceSerivce responseSuervice)
        {
            this.responseSuervice = responseSuervice;
        }


        public async Task<int> Handle(TotalResponseForSurveyQuery request, CancellationToken cancellationToken)
        {

            return await responseSuervice.TotalResponseForSurvey(request.SurvayId);
        }
    }
}
