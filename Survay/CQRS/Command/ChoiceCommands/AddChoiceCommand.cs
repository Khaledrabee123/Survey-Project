using MediatR;

namespace Survay.CQRS.Command.ChoiceCommands
{
    public record AddChoiceToQuestionCommand(int questionId, string text) : IRequest<int>;

}
