using MediatR;
using Survay.DTOs;

namespace Survay.CQRS.Query
{
    public record UserSurveysQuery(string UserId):IRequest<List<UserSurveysDTO>>;
    
}
