using MediatR;
using Survay.DTOs;

namespace Survay.CQRS.Query
{
    public record GetSurveyToEditQuery(int SurvayId):IRequest<surveyDTO>;
    
}
