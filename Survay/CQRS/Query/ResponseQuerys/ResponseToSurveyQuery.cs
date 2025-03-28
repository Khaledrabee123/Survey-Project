using MediatR;
using Survay.DTOs;

namespace Survay.CQRS.Query.ResponseQuerys
{
    public record ResponseToSurveyQuery(int SurveyId) : IRequest<surveyDTO>;

}
