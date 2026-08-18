using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.RepositoryImplementation
{
    public class LocationRepository(AppDbContext context) : ILocationRepository
    {
        public async Task Add(Location location)
        {
            await context.Locations.AddAsync(location);
        }

        public async Task<Location?> Get(Guid id)
        {
            return await context.Locations.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
        }
        public async Task Update(Location location)
        {
            context.Locations.Update(location);
        }
    }
}
