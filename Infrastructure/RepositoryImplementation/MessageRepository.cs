using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RepositoryImplementation
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _context;
        public MessageRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Message message)
        {
            await _context.Messages.AddAsync(message);
        }

        public async Task<Message?> Get(Guid id)
        {
            return await _context.Messages.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Message>> GetAll()
        {
            return await _context.Messages.AsNoTracking().ToListAsync();
        }

        public async Task<List<Message>> GetMessages(Guid senderUserId, Guid recieverUserId)
        {
            return await _context.Messages.AsNoTracking().Where(m => (m.SenderUserId == senderUserId && m.RecieverUserId == recieverUserId) || (m.SenderUserId == recieverUserId && m.RecieverUserId == senderUserId)).ToListAsync();
        }
        public async Task Update(Message message)
        {
            _context.Messages.Update(message);
        }
    }
}
