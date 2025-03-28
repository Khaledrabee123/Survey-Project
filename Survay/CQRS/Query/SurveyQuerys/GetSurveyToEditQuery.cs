using MediatR;
using Survay.DTOs;

namespace Survay.CQRS.Query.SurveyQuerys
{
    public record GetSurveyToEditQuery(int SurvayId) : IRequest<surveyDTO>;

}
