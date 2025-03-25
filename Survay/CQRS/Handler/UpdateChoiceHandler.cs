using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using Survay.CQRS.Command;
using Survay.Models.database;

namespace Survay.CQRS.Handler
{
    public class UpdateChoiceHandler : IRequestHandler<UpdateChoiceCommand>
    {
        db db;

        public UpdateChoiceHandler(db db)
        {
            this.db = db;
        }

        public async Task Handle(UpdateChoiceCommand request, CancellationToken cancellationToken)
        {
            var choice =await db.choses.FirstOrDefaultAsync(c => c.OptionID == request.choiceId);
            choice.OptionText = request.newText;
            db.SaveChanges();
            return;
        }
    }
}
