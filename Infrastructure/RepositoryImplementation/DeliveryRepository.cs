using Application.Interfaces.RepositoryInterfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.RepositoryImplementation
{
    public class DeliveryRepository(AppDbContext context) : IDeliveryRepository
    {
        public async Task Add(Delivery delivery)
        {
            await context.Deliveries.AddAsync(delivery);
        }

        public async Task<Delivery?> Get(Guid id)
        {
            return await context.Deliveries.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Delivery>> GetAll()
        {
            return await context.Deliveries.AsNoTracking().ToListAsync();
        }
        public async Task Update(Delivery delivery)
        {
            context.Deliveries.Update(delivery);
        }
    }
}
