using MediatR;

namespace Survay.CQRS.Command
{
    public record AddQuestionCommand (int SurvayId,string Text):IRequest<int>;
   
}
