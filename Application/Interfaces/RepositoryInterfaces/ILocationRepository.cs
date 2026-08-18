using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
    public interface ILocationRepository
    {
        public Task Add(Location location);
        public Task Update(Location location);
        public Task<Location?> Get(Guid id);
    }
}
