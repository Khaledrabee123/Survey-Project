using System.Security.Claims;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Survay.CQRS.Query;
using Survay.Models.database;
using Survay.Models.DTOs;

namespace Survay.CQRS.Handler
{
    public class UserSurvaysHandler : IRequestHandler<UserSurvaysQuery, List<UserSurevaysDTO>>
    {
        db db;

        public UserSurvaysHandler(db db)
        {
            this.db = db;
        }

        public async Task<List<UserSurevaysDTO>> Handle(UserSurvaysQuery request, CancellationToken cancellationToken)
        {

            var surveys = await db.Surveys.Include(r => r.Responses).Where(e => e.UserID ==request.UserId).ToListAsync();
            List<UserSurevaysDTO> userSurevaysDTOs = surveys.Select(e => new UserSurevaysDTO
            {
                Id = e.SurveyID,
                Title = e.Title,
                Description = e.Description,
                TotalResponses = e.Responses.Count,
                Status = e.IsActive ? "active" : "notActive"
            }).ToList();


            return userSurevaysDTOs;
        }
    }
}
