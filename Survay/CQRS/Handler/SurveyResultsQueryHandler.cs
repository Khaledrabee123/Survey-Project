namespace Survay.CQRS.Handler
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;
    using Survay.CQRS.Query;
    using Survay.Models.database;
    using Survay.Models.DTOs;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class SurveyResultsQueryHandler : IRequestHandler<SurveyResultsQuery, List<object>>
    {
        private readonly db db;
        IMemoryCache _cache;

        public SurveyResultsQueryHandler(db _db, IMemoryCache cache)
        {
            db = _db;
            _cache = cache;
        }

        public async Task<List<object>> Handle(SurveyResultsQuery request, CancellationToken cancellationToken)
        {
            string cacheKey = $"SurveyResults_{request.SurveyId}";

            // Try getting data from cache
            if (_cache.TryGetValue(cacheKey, out List<object> cachedResults))
            {
                return cachedResults;
            }

            var results = await db.Questions
                        .Where(q => q.SurveyID == request.SurveyId)
                        .Select(q => new
                        {
                            question = q.QuestionText,
                            isMCQ = db.choses.Any(c => c.QuestionID == q.QuestionID), 
                            choices = db.choses
                                .Where(c => c.QuestionID == q.QuestionID)
                                .Select(c => new
                                {
                                    choice = c.OptionText,
                                    count = db.Answers.Count(a => a.QuestionID == q.QuestionID) > 0
                                        ? (float)db.Answers.Count(a => a.OptionID == c.OptionID) / db.Answers.Count(a => a.QuestionID == q.QuestionID) * 100
                                        : 0  
                                }).ToList(),
                            response = db.Answers
                                .Where(a => a.QuestionID == q.QuestionID && a.OptionID == null && a.AnswerText != null) 
                                .Select(a => a.AnswerText)
                                .ToList()
                        }).ToListAsync();

            //Caching
            var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(10));
            _cache.Set(cacheKey, results.Cast<object>().ToList(), cacheEntryOptions);


            return results.Cast<object>().ToList();
        }

    }

}
