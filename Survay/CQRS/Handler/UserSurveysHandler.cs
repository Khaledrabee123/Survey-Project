using System.Security.Claims;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Survay.CQRS.Query;
using Survay.DTOs;
using Survay.Models.database;
using Survay.Services.SurvayServices;

namespace Survay.CQRS.Handler
{
    public class UserSurveysHandler : IRequestHandler<UserSurveysQuery, List<UserSurveysDTO>>
    {
        ISurveyServices surveyServices;

        public UserSurveysHandler( ISurveyServices surveyServices)
        {
            this.surveyServices = surveyServices;
        }

        public async Task<List<UserSurveysDTO>> Handle(UserSurveysQuery request, CancellationToken cancellationToken)
        {

            var userSurevaysDTOs =await surveyServices.GetUserSurveysAsync(request.UserId);


            return userSurevaysDTOs;
        }
    }
}
