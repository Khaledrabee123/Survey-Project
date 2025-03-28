using MediatR;

namespace Survay.CQRS.Command.SurvayCommnds
{
    public record UpdateSurveyCommand(int SurveyId, string field, string Value) : IRequest<bool>;


}
