using MediatR;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.CQRS.Command.SurvayCommnds
{
    public record AddSurveyCommand(Survey Survay) : IRequest;
}
