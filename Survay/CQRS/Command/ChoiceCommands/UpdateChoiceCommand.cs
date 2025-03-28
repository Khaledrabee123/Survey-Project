using MediatR;

namespace Survay.CQRS.Command.ChoiceCommands
{
    public record UpdateChoiceCommand(int choiceId, string newText) : IRequest;


}
