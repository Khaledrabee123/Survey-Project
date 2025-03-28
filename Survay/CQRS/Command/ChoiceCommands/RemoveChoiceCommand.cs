using MediatR;
using Survay.Models.database;

namespace Survay.CQRS.Command.ChoiceCommands
{
    public record RemoveChoiceCommand(Choice Choice) : IRequest;

}
