using Domain.Entities;

namespace Application.Interfaces.Repository
{
    public interface ILocationRepository
    {
        public Task Add(Location location);
        public Task Update(Location location);
        public Task<Location?> Get(Guid id);
    }
}
