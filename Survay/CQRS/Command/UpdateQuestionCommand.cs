using MediatR;

namespace Survay.CQRS.Command
{
    public record UpdateQuestionCommand(int QuestionId,String field, String Value):IRequest<bool>;
  
}
