﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Survay.CQRS.Query;
using Survay.Models.database;
using Survay.Models.DTO;

namespace Survay.CQRS.Handler
{
    public class ResponseToSurvayHandler : IRequestHandler<ResponseToSurvayQuery, serveyDTO>
    {
        db db;

        public ResponseToSurvayHandler(db db)
        {
            this.db = db;
        }

        public async Task<serveyDTO> Handle(ResponseToSurvayQuery request, CancellationToken cancellationToken)
        {
            var s = await db.Surveys
        .Where(e => e.SurveyID == request.SurveyId)
        .Include(s => s.Questions)
        .ThenInclude(q => q.Choices)
        .Select(s => new serveyDTO
         {
             SurveyID = s.SurveyID,
             UserID = s.UserID,
             Title = s.Title,
             Description = s.Description,
             IsActive = s.IsActive,
             CreatedAt = s.CreatedAt,
             Questions = s.Questions.Select(q => new QuestionDTO
        {
             QuestionID = q.QuestionID,
             QuestionNumber = q.QuestionNumber,
             QuestionText = q.QuestionText,
             QuestionType = q.QuestionType,
             CreatedAt = q.CreatedAt,
             choseDTOs = q.Choices.Select(c => new ChoiceDTO
         {
             Id = c.OptionID,
             Text = c.OptionText
         }).ToList()
         }).ToList()
            }).FirstOrDefaultAsync();
            return s;
        }
    }
}
