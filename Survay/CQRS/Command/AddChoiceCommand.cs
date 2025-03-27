using MediatR;

namespace Survay.CQRS.Command
{
    public record AddChoiceToQuestionCommand(int questionId, string text):IRequest<int>;
    
}
