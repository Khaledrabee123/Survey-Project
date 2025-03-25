using MediatR;
using Survay.Models.database;

namespace Survay.CQRS.Query
{
    public record GetChoiceByIdQuery(int ChoiceId ):IRequest<Choice>;
    
}
