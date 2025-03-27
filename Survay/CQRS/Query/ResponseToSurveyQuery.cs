using MediatR;
using Survay.DTOs;

namespace Survay.CQRS.Query
{
    public record ResponseToSurveyQuery(int SurveyId) : IRequest<surveyDTO>;
   
}
