using Azure.Core;
using MediatR;
using Survay.Models.database;
using Survay.Repositores.ChoiceRepo;

namespace Survay.Services.ChoiceServices
{
    
    public class ReadChoiceServices : IReadChoiceServices
    {
        private readonly IReadChoiceRepository _choiceRepository;

        public ReadChoiceServices(IReadChoiceRepository choiceRepository)
        {
            _choiceRepository = choiceRepository;
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

        

       

    }
}
