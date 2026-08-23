using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace Application.Dtos
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public IFormFile Profile { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public Guid UserId { get; set; }
        public List<DeliveryRequest> ClientDeliveryRequests { get; set; } = [];
        public List<Notification> UserNotifications { get; set; } = [];
        public string FullName => $"{FirstName} {LastName}";

    }
    public record AddClientRequestModel(string FirstName, string LastName, string Email, string PhoneNumber, string Password, IFormFile Profile);
    public record AddClientResponseModel(Guid Id);
}
