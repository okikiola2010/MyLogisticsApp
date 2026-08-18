using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class DeliverManDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public string WorkId { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string MiniTime { get; set; } = default!;
        public DateTime LastTimeOrdered { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
    public record AddDeliverManRequestModel(string FirstName, string LastName, string Email, string Password, string CreatedBy);
    public record AddDeliverManResponseModel(Guid Id);
}
