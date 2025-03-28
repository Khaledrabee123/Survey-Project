using MediatR;
using Survay.DTOs;

namespace Survay.CQRS.Query.SurveyQuerys
{
    public record UserSurveysQuery(string UserId) : IRequest<List<UserSurveysDTO>>;

}
