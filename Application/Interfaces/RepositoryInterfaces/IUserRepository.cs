using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        public Task Add(User User);
        public Task Update(User User);
        public Task<User?> Get(Guid id); 
        public Task<User?> Get(string email);
    }
}
