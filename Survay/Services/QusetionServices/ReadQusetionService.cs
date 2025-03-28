using Azure.Core;
using MediatR;
using Survay.Models.database;
using Survay.Repositores.QuserionRepo;

namespace Survay.Services.QusetionServices
{
    public class ReadQusetionService : IReadQusetionServices
    {
        IReadQusetionRepository questionRepository;

        public ReadQusetionService(IReadQusetionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        public Question Get(int QuestionId)
        {
            return questionRepository.Get(QuestionId);
        }

        public Question make(string Text)
        {
            return new Question
            {
                QuestionText = Text,
                QuestionType = "MCQ",
                Choices = new List<Choice>()
            };
        }

    }
}
