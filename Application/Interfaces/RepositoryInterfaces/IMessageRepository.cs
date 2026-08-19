using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
    public interface IMessageRepository
    {
        public Task Add(Message message);
        public Task Update(Message message);
        public Task<Message?> Get(Guid id);
        public Task<List<Message>> GetMessages(string senderEmail,string recieverEmail);
        public Task<List<Message>> GetAll();
    }
}
