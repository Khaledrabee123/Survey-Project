using Survay.Models.database;

namespace Survay.Services.QusetionServices
{
    public interface IReadQusetionServices
    {

        public Question Get(int QuestionId);
        public Question make(String Text);

    }
}
