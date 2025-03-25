using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Query;
using Survay.Models.database;

namespace Survay.CQRS.Handler
{
    public class TotalResponseForSurvayHandler:IRequestHandler<TotalResponseForSurveyQuery, int>
    {
        private readonly db db;

        public TotalResponseForSurvayHandler(db db)
        {
            this.db = db;
        }

        public async Task<int> Handle(TotalResponseForSurveyQuery request, CancellationToken cancellationToken)
        {
            int TotalResponse = await db.Responses.CountAsync(e => e.SurveyID == request.SurvayId);
            return TotalResponse;
        }
    }
}
