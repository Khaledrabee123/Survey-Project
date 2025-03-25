using MediatR;
using Survay.Models.DTOs;

namespace Survay.CQRS.Query
{
    public record UserSurvaysQuery(string UserId):IRequest<List<UserSurevaysDTO>>;
    
}
