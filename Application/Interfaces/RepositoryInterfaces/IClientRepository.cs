using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.RepositoryInterfaces
{
    public interface IClientRepository
    {
        public Task Add(Client client);
        public Task<Client?> Get(Guid id);
        public Task<Client?> Get(string phoneNumber);
        public Task<Client?> GetByUserId(Guid userId);
        public Task<List<Client>> GetAll();
        public Task Update(Client client);

    }
}
