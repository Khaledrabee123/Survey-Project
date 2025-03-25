using MediatR;

namespace Survay.CQRS.Command
{
    public record UpdateChoiceCommand(int choiceId, string newText):IRequest;


}
