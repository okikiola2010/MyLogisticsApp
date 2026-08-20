using Application.Interfaces.RepositoryInterfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.RepositoryImplementation
{
    public class DeliverManRepository(AppDbContext context) : IDeliveryManRepository
    {
        public async Task Add(DeliveryMan deliveryMan)
        {
            await context.DeliveryMen.AddAsync(deliveryMan);
        }

        public async Task<DeliveryMan?> Get(Guid id)
        {
            return await context.DeliveryMen.AsNoTracking().Include(x => x.Deliveries).Include(d => d.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DeliveryMan?> Get(string workId)
        {
            return await context.DeliveryMen.AsNoTracking().Include(x => x.Deliveries).Include(d => d.User).FirstOrDefaultAsync(x => x.WorkId == workId);
        }

        public async Task<List<DeliveryMan>> GetAll()
        {
            return await context.DeliveryMen.AsNoTracking().Include(x => x.Deliveries).Include(d => d.User).ToListAsync();
        }
        public async Task Update(DeliveryMan deliveryMan)
        {
            context.DeliveryMen.Update(deliveryMan);
        }
    }
}
