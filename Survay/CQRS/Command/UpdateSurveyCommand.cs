using MediatR;

namespace Survay.CQRS.Command
{
    public record UpdateSurveyCommand (int SurveyId, String field, String Value) : IRequest<bool>;

   
}
