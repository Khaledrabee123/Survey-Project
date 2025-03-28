using MediatR;
using Survay.Models.database;

namespace Survay.CQRS.Command.SurvayCommnds
{
    public record DeleteSurveycommand(int SurveyId) : IRequest;

}
