using Survay.DTOs;
using Survay.Models.database;
using Survay.Repositores.ResponseRepo;

namespace Survay.Services.ResponsesServices
{
    public class WriteResponseSerices : IWriteResponseSerices
    {
        IWriteResponseRepository writeResponseRepository;

        public WriteResponseSerices(IWriteResponseRepository writeResponseRepository)
        {
            this.writeResponseRepository = writeResponseRepository;
        }

        public Task add(Response response)
        {
            writeResponseRepository.add(response);
            return Task.CompletedTask;
        }


    }
}
