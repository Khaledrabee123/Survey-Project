using MediatR;
using Survay.Models.database;

namespace Survay.CQRS.Query.ChoiceQuerys
{
    public record GetChoiceByIdQuery(int ChoiceId) : IRequest<Choice>;

}
