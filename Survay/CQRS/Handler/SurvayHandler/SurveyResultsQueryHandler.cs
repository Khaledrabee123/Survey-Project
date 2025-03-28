namespace Survay.CQRS.Handler.SurvayHandler
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;
    using Survay.CQRS.Query.SurveyQuerys;
    using Survay.Models.database;
    using Survay.Services.SurvayServices;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class SurveyResultsQueryHandler : IRequestHandler<SurveyResultsQuery, List<object>>
    {
        IReadSurveyServices surveyServices;

        public SurveyResultsQueryHandler(IReadSurveyServices surveyServices)
        {
            this.surveyServices = surveyServices;
        }



        public async Task<List<object>> Handle(SurveyResultsQuery request, CancellationToken cancellationToken)
        {


            return await surveyServices.GetSurveyResultsAsync(request.SurveyId);
        }

    }

}
