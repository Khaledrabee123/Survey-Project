using MediatR;
using Survay.Models.database;

namespace Survay.CQRS.Command
{
    public record DeleteSurvaycommand(int SurveyId) : IRequest;
   
}
