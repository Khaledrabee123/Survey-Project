using Survay.Models.database;
using Survay.Repositores.ChoiceRepo;

namespace Survay.Services.ChoiceServices
{
    public class WriteChoiceService : IWriteChoiceServices
    {
      private readonly  IWriteChoiceRepository _choiceRepository;
        IReadChoiceServices _readChoiceServices;
        public WriteChoiceService(IWriteChoiceRepository choiceRepository, IReadChoiceServices readChoiceServices)
        {
            this._choiceRepository = choiceRepository;
            _readChoiceServices = readChoiceServices;
        }

        public Task Add(Choice Choice)
        {
            _choiceRepository.Add(Choice);
            return Task.CompletedTask;
        }
        public async Task Update(int id, String Text)
        {
            var choice = await _readChoiceServices.Get(id);

            choice.OptionText = Text;

            _choiceRepository.Update(choice);
        }

        public Task Remove(Choice Choice)
        {
            _choiceRepository.Delete(Choice);
            return Task.CompletedTask;
        }
    }
}
