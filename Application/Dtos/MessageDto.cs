using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class MessageDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CreatedBy { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; } = default!;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = default;
        public string SenderEmail { get; set; } = default!;
        public User? Sender { get; set; }
        public string RecieverEmail { get; set; } = default!;
        public User? Reciever { get; set; }
        public string Context { get; set; } = default!;
    }
    public record AddMessageRequestModel(string SenderEmail, string RecieverEmail);
    public record AddMessageResponseModel(Guid Id);
}
