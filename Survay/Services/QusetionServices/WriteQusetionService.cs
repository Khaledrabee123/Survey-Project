using Survay.Models.database;
using Survay.Repositores.QuserionRepo;

namespace Survay.Services.QusetionServices
{
    public class WriteQusetionService : IWriteQusetionServices
    {
        IWriteQuestionRepository questionRepository;
        IReadQusetionServices readquestionServices;
        public WriteQusetionService(IWriteQuestionRepository questionRepository, IReadQusetionServices readquestionServices)
        {
            this.questionRepository = questionRepository;
            this.readquestionServices = readquestionServices;
        }

        public Task AddChoice(int QuestionId, Choice choice)
        {
            return questionRepository.AddChoice(QuestionId, choice);
        }

        public Task Remove(int questionId)
        {

            return questionRepository.Remove(readquestionServices.Get(questionId));
        }

        public Task Update(int QusetionId, String field, String Value)
        {

            var question = readquestionServices.Get(QusetionId);

            if (field == "text")
            {
                question.QuestionText = Value;
            }
            else if (field == "type")
            {
                question.QuestionType = Value;
            }
            return questionRepository.Update(question);
        }
    }
}
