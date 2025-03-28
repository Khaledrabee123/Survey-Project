using MediatR;

namespace Survay.CQRS.Command.QuserionCommands
{
    public record UpdateQuestionCommand(int QuestionId, string field, string Value) : IRequest<bool>;

}
