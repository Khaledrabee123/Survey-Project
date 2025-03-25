using MediatR;
using Survay.Models.DTO;

namespace Survay.CQRS.Query
{
    public record GetSurvayToEditQuery(int SurvayId):IRequest<servayDTO>;
    
}
