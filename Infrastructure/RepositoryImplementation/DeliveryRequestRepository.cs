using Application.Interfaces.RepositoryInterfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.RepositoryImplementation
{
    public class DeliveryRequestRepository(AppDbContext context) : IDeliveryRequestRepository
    {                                        
        public async Task Add(DeliveryRequest deliveryRequest)
        {                                    
            await context.DeliveryRequests.AddAsync(deliveryRequest);
        }                                    
                                             
        public async Task<DeliveryRequest?> Get(Guid id)
        {                                    
            return await context.DeliveryRequests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }                                    
        public async Task<List<DeliveryRequest>> GetByCustomerId(Guid customerId)
        {                                    
            return await context.DeliveryRequests.AsNoTracking().Where(x => x.CustomerId == customerId).ToListAsync();
        }                                    
                                             
        public async Task<List<DeliveryRequest>> GetAll()
        {
            return await context.DeliveryRequests.AsNoTracking().ToListAsync();
        }
        public async Task Update(DeliveryRequest deliveryRequest)
        {
            context.DeliveryRequests.Update(deliveryRequest);
        }

    }
}
