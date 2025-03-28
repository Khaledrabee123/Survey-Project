using MediatR;
using Survay.Models.database;

namespace Survay.CQRS.Query.ChoiceQuerys
{
    public record IsChoiceHasAnswersQuery(int choiceId) : IRequest<bool>;

}
