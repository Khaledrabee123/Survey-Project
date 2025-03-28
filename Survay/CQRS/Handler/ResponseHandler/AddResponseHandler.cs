using MediatR;
using Survay.CQRS.Command.ResponseCommnds;
using Survay.Models.database;
using Survay.Services.ResponsesServices;

namespace Survay.CQRS.Handler.ResponseHandler
{
    public class AddResponseHandler : IRequestHandler<AddResponseCommand>
    {
        IWriteResponseSerices WriteresponceSerivce;

        public AddResponseHandler(IWriteResponseSerices WriteresponceSerivce)
        {
            this.WriteresponceSerivce = WriteresponceSerivce;
        }

        public Task Handle(AddResponseCommand request, CancellationToken cancellationToken)
        {

            WriteresponceSerivce.add(request.response);
            return Task.CompletedTask;
        }
    }
}
