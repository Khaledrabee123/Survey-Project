using MediatR;

namespace Survay.CQRS.Command.QuserionCommands
{
    public record RemoveQuestionCommand(int QusetionId) : IRequest<bool>;

}
