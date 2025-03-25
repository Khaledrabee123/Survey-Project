using MediatR;

namespace Survay.CQRS.Command
{
    public record AddChoiceCommand(int questionId, string text):IRequest<int>;
    
}
