using Domain.Entities;

namespace Application.Interfaces.Repository
{
    public interface IMessageRepository
    {
        public Task Add(Message message);
        public Task Update(Message message);
        public Task<Message?> Get(Guid id);
        public Task<List<Message>> GetMessages(Guid senderUserId, Guid recieverUserId);
        public Task<List<Message>> GetAll();
    }
}
