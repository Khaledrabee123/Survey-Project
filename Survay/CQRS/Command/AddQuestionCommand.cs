using MediatR;

namespace Survay.CQRS.Command
{
    public record AddQuestionToSurveyCommand (int SurvayId,string Text):IRequest<int>;
   
}
