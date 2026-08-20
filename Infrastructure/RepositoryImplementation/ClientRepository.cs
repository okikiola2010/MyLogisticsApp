using Application.Interfaces.RepositoryInterfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.RepositoryImplementation
{
    public class ClientRepository(AppDbContext context) : IClientRepository
    {
        public async Task Add(Client client)
        {
            await context.Clients.AddAsync(client);
        }

        public async Task<Client?> Get(Guid id)
        {
            return await context.Clients.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Client?> Get(string phoneNumber)
        {
            return await context.Clients.AsNoTracking().Include(c => c.User).Include(c => c.ClientDeliveryRequests).Include(c => c.UserNotifications).FirstOrDefaultAsync(c => c.PhoneNumber == phoneNumber);
        }

        public async Task<List<Client>> GetAll()
        {
            return await context.Clients.AsNoTracking().Include(c => c.User).Include(c => c.ClientDeliveryRequests).Include(c => c.UserNotifications).ToListAsync();
        }

        public async Task<Client?> GetByUserId(Guid userId)
        {
            return await context.Clients.AsNoTracking().Include(c => c.User).Include(c => c.ClientDeliveryRequests).Include(c => c.UserNotifications).FirstOrDefaultAsync(c => c.UserId == userId);

        }
        public async Task Update(Client client)
        {
             context.Clients.Update(client);
        }
    }
}
