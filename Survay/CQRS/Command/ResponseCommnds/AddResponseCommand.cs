using MediatR;
using Survay.Models.database;

namespace Survay.CQRS.Command.ResponseCommnds
{
    public record AddResponseCommand(Response response) : IRequest;

}
