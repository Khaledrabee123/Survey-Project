using Azure.Core;
using MediatR;
using Survay.Models.database;
using Survay.Repositores.ChoiceRepo;

namespace Survay.Services.ChoiceServices
{
    
    public class ChoiceServices : IChoiceServices
    {
        private readonly IChoiceRepository _choiceRepository;

        public ChoiceServices(IChoiceRepository choiceRepository)
        {
            _choiceRepository = choiceRepository;
        }

        public Task Add(Choice Choice)
        {
             _choiceRepository.Add(Choice);
             return Task.CompletedTask;
        }

        public Task<Choice> Get(int id)
        {
            return _choiceRepository.Get(id);
        }

        public Task<int> GetChoiceAnswersCountAsync(int choiceId)
        {
           return  _choiceRepository.GetChoiceAnswersCountAsync(choiceId);
        }

        public bool IsChoiceHasAnswersQuery(int id)
        {
            return _choiceRepository.IsChoiceHasAnswersQuery(id);
        }

        public Task<bool> IsMCQAsync(int questionId)
        {
           return _choiceRepository.IsMCQAsync(questionId);
        }

        public Choice MakeChoice(string Text)
        {
            return new Choice { OptionText = Text };
        }

        public Task Remove(Choice Choice)
        {
           _choiceRepository.Delete(Choice);
            return Task.CompletedTask;
        }

        public async Task Update(int id , String Text)
        {
            var choice =await _choiceRepository.Get(id);
            
            choice.OptionText =Text ;
            
            _choiceRepository.Update(choice);    
        }


    }
}
