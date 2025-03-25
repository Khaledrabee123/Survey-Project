using MediatR;
using Survay.Models.DTO;

namespace Survay.CQRS.Query
{
    public record ResponseToSurvayQuery(int SurveyId):IRequest<serveyDTO>;
   
}
