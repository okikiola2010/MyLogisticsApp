using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Domain.Entities
{
    public class DeliveryMan:BaseEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public string WorkId { get; set; } = default!;
        public DateTime LastTimeOrdered { get; set; }
        public string MiniTime => GetMiniTime();
        public string FullName => $"{FirstName} {LastName}";
        private DeliveryMan() { }
        public DeliveryMan(string firstName, string lastName, Guid userId,string createdBy)
        {
            FirstName = firstName;
            LastName = lastName;
            UserId = userId;
            CreatedBy = createdBy;
            LastTimeOrdered = CreatedAt;
            WorkId = GenerateWorkId(firstName, lastName);
        }
        public string GetMiniTime()
        {
            return $"{LastTimeOrdered.Second}{LastTimeOrdered.Millisecond}{LastTimeOrdered.Microsecond}{LastTimeOrdered.Nanosecond}";
        }
        string GenerateWorkId(string firstName, string lastName)
        {
            Random random = new Random();
            int b = random.Next(111111, 999999);
            string r = $"{b}-{Guid.NewGuid().ToString().Split("-")[0].ToString().ToUpper()}@{firstName[0].ToString().ToUpper()}{lastName[0].ToString().ToUpper()}".ToUpper();
            return r;
        }
        public void Update(string firstName, string lastName, Guid userId,  string updatedBy, bool isDeleted, DateTime lastTimeOrdered)
        {
            FirstName = firstName;
            LastName = lastName;
            UserId = userId;
            LastTimeOrdered = lastTimeOrdered;
            UpdatedBy = updatedBy;
            UpdatedAt = DateTime.UtcNow;
            IsDeleted = isDeleted;
        }
    }
}
