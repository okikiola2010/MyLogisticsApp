using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.RepositoryInterfaces
{
    public interface ICommunityRepository
    {
        public Task Add(Community community);
        public Task Update(Community community);
        public Task<Community?> Get(Guid id);
        public Task<Community?> Get(string name);
        public Task<List<Community>> GetCommunitiesByLgaId(Guid lgaId);
    }
}
