using Survay.Models.database;

namespace Survay.Repositores.ResponseRepo
{
    public interface IWriteResponseRepository
    {
        public Task add(Response response);

    }
}
