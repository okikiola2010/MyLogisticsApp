using Application.Interfaces.RepositoryInterfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.RepositoryImplementation
{
    public class CommunityRepository(AppDbContext context) : ICommunityRepository
    {
        public async Task Add(Community community)
        {
                await context.Communities.AddAsync(community);
        }

        public async Task<Community?> Get(Guid id)
        {
            return await context.Communities.AsNoTracking().Include(x => x.Lga).Include(x => x.Lga!.State).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Community?> Get(string name)
        {     
            return await context.Communities.AsNoTracking().Include(x => x.Lga).Include(x => x.Lga!.State).FirstOrDefaultAsync(c => c.Name == name);
        }     
              
        public async Task<List<Community>> GetCommunitiesByLgaId(Guid lgaId)
        {
            return await context.Communities.AsNoTracking().Include(x => x.Lga).Include(x => x.Lga!.State).Where(c => c.LgaId == lgaId).ToListAsync();
        }
        public async Task Update(Community community)
        {
            context.Communities.Update(community);
        }
    }
}
