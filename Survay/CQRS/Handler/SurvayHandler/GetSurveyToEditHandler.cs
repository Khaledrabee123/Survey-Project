using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Survay.CQRS.Query.SurveyQuerys;
using Survay.DTOs;
using Survay.Models.database;
using Survay.Services.SurvayServices;

namespace Survay.CQRS.Handler.SurvayHandler
{
    public class GetSurveyToEditHandler : IRequestHandler<GetSurveyToEditQuery, surveyDTO>
    {
        IReadSurveyServices readSurveyServices;

        public GetSurveyToEditHandler(IReadSurveyServices readSurveyServices)
        {
            this.readSurveyServices = readSurveyServices;
        }

        public async Task<surveyDTO> Handle(GetSurveyToEditQuery request, CancellationToken cancellationToken)
        {



            return await readSurveyServices.GetSurveyToEditAsync(request.SurvayId);

        }

    }
}
