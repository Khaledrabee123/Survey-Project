using MediatR;

namespace Survay.CQRS.Query
{
    public record TotalResponseForSurveyQuery(int SurvayId): IRequest<int>;
}
