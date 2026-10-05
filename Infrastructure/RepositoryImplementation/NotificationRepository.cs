using Application.Interfaces.RepositoryInterfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RepositoryImplementation
{
    public class NotificationRepository(AppDbContext context) : INotificationRepository
    {
        public async Task Add(Notification notification)
        {
            await context.Notifications.AddAsync(notification);
        }

        public async Task<Notification?> Get(Guid id)
        {
            return await context.Notifications.AsNoTracking().FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<List<Notification>> GetAll()
        {
            return await context.Notifications.AsNoTracking().ToListAsync();
        }

        public async Task<List<Notification>> GetUserNotifications(Guid userId)
        {
            return await context.Notifications.AsNoTracking().Where(n => n.UserId == userId).ToListAsync();
        }
        public async Task Update(Notification notification)
        {
            context.Notifications.Update(notification);
        }
    }
}
