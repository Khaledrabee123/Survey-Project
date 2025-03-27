using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Query;
using Survay.Models.database;
using Survay.Services.ResponsesServices;

namespace Survay.CQRS.Handler
{
    public class TotalResponseForSurveyHandler:IRequestHandler<TotalResponseForSurveyQuery, int>
    {
        IResponceSerivce responseSuervice;

        public TotalResponseForSurveyHandler(IResponceSerivce responseSuervice)
        {
            this.responseSuervice = responseSuervice;
        }

       
        public async Task<int> Handle(TotalResponseForSurveyQuery request, CancellationToken cancellationToken)
        {

            return await responseSuervice.TotalResponseForSurvey(request.SurvayId);
        }
    }
}
