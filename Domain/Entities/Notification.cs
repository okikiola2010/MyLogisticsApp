using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Notification:BaseEntity
    {
        public Guid UserId {  get; set; }
        public User? User {  get; set; }
        public string Context { get; set; } = default!;
        private Notification() { }
        public Notification(string context, Guid userId, string createdBy)
        {
            UserId = userId;
            Context = context;
            CreatedBy = createdBy;
        }
        public void Update(string context, Guid userId, string updatedBy, bool isDeleted)
        {
            Context = context;
            IsDeleted = isDeleted;
            UserId = userId;
            UpdatedBy = updatedBy;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
