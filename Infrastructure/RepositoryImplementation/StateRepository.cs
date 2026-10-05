using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RepositoryImplementation
{
    public class StateRepository(AppDbContext context) : IStateRepository
    {
        public async Task Add(State state)
        {
            await context.States.AddAsync(state);
        }

        public async Task<State?> Get(Guid id)
        {
            return await context.States.AsNoTracking().Include(s => s.Lgas).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<State?> Get(string name)
        {
            return await context.States.AsNoTracking().Include(s => s.Lgas).FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task<List<State>> GetAll()
        {
            return await context.States.AsNoTracking().Include(s => s.Lgas).ToListAsync();
        }
        public async Task Update(State state)
        {
            context.States.Update(state);
        }
    }
}
