using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.RepositoryInterfaces
{
    public interface INotificationRepository
    {
        public Task Add(Notification notification);
        public Task Update(Notification notification);
        public Task<Notification?> Get(Guid id);
        public Task<List<Notification>> GetUserNotifications(Guid userId);
        public Task<List<Notification>> GetAll();
    }
}
