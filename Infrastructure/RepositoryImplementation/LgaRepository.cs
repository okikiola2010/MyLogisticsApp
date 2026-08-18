using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.RepositoryImplementation
{
    public class LgaRepository(AppDbContext context) : ILgaRepository
    {
        public async Task Add(Lga lga)
        {
            await context.Lgas.AddAsync(lga);
        }

        public async Task<Lga?> Get(Guid id)
        {
            return await context.Lgas.AsNoTracking().Include(l => l.State).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Lga?> Get(string name)
        {
            return await context.Lgas.AsNoTracking().Include(l => l.State).FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<Lga>> GetLgasByStateId(Guid stateId)
        {
            return await context.Lgas.AsNoTracking().Where(x => x.StateId == stateId).Include(l => l.State).ToListAsync();
        }
        public async Task Update(Lga lga)
        {
            context.Lgas.Update(lga);
        }
    }
}
