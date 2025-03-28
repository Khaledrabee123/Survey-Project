using System.Security.Claims;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Survay.CQRS.Query.SurveyQuerys;
using Survay.DTOs;
using Survay.Models.database;
using Survay.Services.SurvayServices;

namespace Survay.CQRS.Handler.SurvayHandler
{
    public class UserSurveysHandler : IRequestHandler<UserSurveysQuery, List<UserSurveysDTO>>
    {
        IReadSurveyServices readSurveyServices;

        public UserSurveysHandler(IReadSurveyServices readSurveyServices)
        {
            this.readSurveyServices = readSurveyServices;
        }



        public async Task<List<UserSurveysDTO>> Handle(UserSurveysQuery request, CancellationToken cancellationToken)
        {

            var userSurevaysDTOs = await readSurveyServices.GetUserSurveysAsync(request.UserId);


            return userSurevaysDTOs;
        }
    }
}
