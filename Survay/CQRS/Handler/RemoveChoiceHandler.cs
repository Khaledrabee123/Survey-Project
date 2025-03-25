using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using Survay.CQRS.Command;
using Survay.Models.database;

namespace Survay.CQRS.Handler
{
    public class RemoveChoiceHandler : IRequestHandler<RemoveChoiceCommand>
    {
        db db;

        public RemoveChoiceHandler(db db)
        {
            this.db = db;
        }

        public Task Handle(RemoveChoiceCommand request, CancellationToken cancellationToken)
        {
            db.Remove(request.Choice);
            db.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
