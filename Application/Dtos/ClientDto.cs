using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Application.Dtos
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public string FullName => $"{FirstName} {LastName}";

    }
    public record AddClientRequestModel(string FirstName, string LastName, string Email, string PhoneNumber, string Password, string CreatedBy);
    public record AddClientResponseModel(Guid Id);
}
