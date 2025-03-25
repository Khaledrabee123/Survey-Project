using MediatR;
using Survay.Models.database;

namespace Survay.CQRS.Command
{
    public record RemoveChoiceCommand(Choice Choice):IRequest;
   
}
