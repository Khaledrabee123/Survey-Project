using MediatR;
using Survay.CQRS.Command;
using Survay.Models.database;
using Survay.Services.ResponsesServices;

namespace Survay.CQRS.Handler
{
    public class AddResponseHandler : IRequestHandler<AddResponseCommand>
    {
        IResponceSerivce responceSerivce;

        public AddResponseHandler(IResponceSerivce responceSerivce)
        {
            this.responceSerivce = responceSerivce;
        }

        public Task Handle(AddResponseCommand request, CancellationToken cancellationToken)
        {

            responceSerivce.add(request.response);
            return Task.CompletedTask; 
        }
    }
}
