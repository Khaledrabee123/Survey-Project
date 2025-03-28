using MediatR;

namespace Survay.CQRS.Command.SurvayCommnds
{
    public record AddQuestionToSurveyCommand(int SurvayId, string Text) : IRequest<int>;

}
