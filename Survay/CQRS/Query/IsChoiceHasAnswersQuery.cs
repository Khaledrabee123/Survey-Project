using MediatR;
using Survay.Models.database;

namespace Survay.CQRS.Query
{
    public record IsChoiceHasAnswersQuery(int choiceId) :IRequest<bool>;
 
}
