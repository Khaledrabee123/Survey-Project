using MediatR;

namespace Survay.CQRS.Command
{
    public record RemoveQuestionCommand( int QusetionId):IRequest<bool>;
    
}
