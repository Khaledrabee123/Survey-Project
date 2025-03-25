using MediatR;
using Survay.Models.DTOs;
using System.Collections.Generic;

namespace Survay.CQRS.Query
{

    public record SurveyResultsQuery(int SurveyId) : IRequest<List<object>>;

}
