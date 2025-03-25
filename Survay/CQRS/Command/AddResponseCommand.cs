using MediatR;
using Survay.Models.database;

namespace Survay.CQRS.Command
{
    public record AddResponseCommand(Response response):IRequest;

}
