using Domain.Entities;

namespace Application.Interfaces.Repository
{
    public interface IStateRepository
    {
        public Task Add(State state);
        public Task Update(State state);
        public Task<State?> Get(Guid id);
        public Task<State?> Get(string name);
        public Task<List<State>> GetAll();
    }
}
