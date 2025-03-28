using Survay.Models.database;

namespace Survay.Services.ResponsesServices
{
    public interface IWriteResponseSerices
    {
        public Task add(Response response);
    }
}
