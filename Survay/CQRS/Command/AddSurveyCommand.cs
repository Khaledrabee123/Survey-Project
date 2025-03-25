using MediatR;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.CQRS.Command
{
    public record AddSurveyCommand(Servay Survay):IRequest;
}
