using MediatR;
using Survay.Models.database;

namespace Survay.CQRS.Command
{
    public record DeleteSurveycommand(int SurveyId) : IRequest;
   
}
