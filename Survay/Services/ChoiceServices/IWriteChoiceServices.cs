using Survay.Models.database;

namespace Survay.Services.ChoiceServices
{
    public interface IWriteChoiceServices
    {
        public Task Add(Choice Choice);
        public Task Remove(Choice Choice);
        public Task Update(int id, String Text);
    }
}
