using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Query;
using Survay.Models.database;

namespace Survay.CQRS.Handler
{
    public class GetChoiceByIdHandler : IRequestHandler<GetChoiceByIdQuery, Choice>
    {
        db db;

        public GetChoiceByIdHandler(db db)
        {
            this.db = db;
        }

        public async Task<Choice> Handle(GetChoiceByIdQuery request, CancellationToken cancellationToken)
        {
            return await db.choses.FirstOrDefaultAsync(c=>c.OptionID== request.ChoiceId);
        }
    }
}
