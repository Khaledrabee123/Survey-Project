using Azure.Core;
using MediatR;
using Survay.Models.database;
using Survay.Repositores.QuserionRepo;

namespace Survay.Services.QusetionServices
{
    public class QusetionService : IQusetionServices
    {
        IQuestionRepository questionRepository;

        public QusetionService(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        public Task AddChoice(int QuestionId, Choice choice)
        {
            return  questionRepository.AddChoice(QuestionId, choice);
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

        public Task Remove(int questionId)
        {

           return questionRepository.Remove(questionRepository.Get(questionId));
        }

        public Task Update(int QusetionId, String field , String Value)
        {

           var question = questionRepository.Get(QusetionId);

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
