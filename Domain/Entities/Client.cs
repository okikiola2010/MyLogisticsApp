using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Client:BaseEntity
    {
        public string FirstName {  get; set; } = default!;
        public string LastName {  get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public Guid UserId { get;  set; }
        public User? User { get;  set; }
        public string FullName => $"{FirstName} {LastName}";
        public List<Notification> Notifications { get; set; } = [];
        private Client() { }
        public Client(string firstName, string lastName, Guid userId, string phoneNumber, string createdBy)
        {
            FirstName = firstName;
            LastName = lastName;
            UserId = userId;
            PhoneNumber = phoneNumber;
            CreatedBy = createdBy;
        }
        public void Update(string firstName, string lastName, Guid userId, string phoneNumber, string updatedBy, bool isDeleted, string miniTime)
        {
            FirstName = firstName;
            LastName = lastName;
            UserId = userId;
            PhoneNumber = phoneNumber;
            UpdatedBy = updatedBy;
            UpdatedAt = DateTime.UtcNow;
            IsDeleted = isDeleted;
        }
    }
}
