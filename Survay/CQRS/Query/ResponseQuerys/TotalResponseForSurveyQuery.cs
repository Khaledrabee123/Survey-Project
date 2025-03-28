using MediatR;

namespace Survay.CQRS.Query.ResponseQuerys
{
    public record TotalResponseForSurveyQuery(int SurvayId) : IRequest<int>;
}
