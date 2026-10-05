using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public string ProfileString { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public Guid UserId { get; set; }
        public List<DeliveryRequest> ClientDeliveryRequests { get; set; } = [];
        public List<Notification> UserNotifications { get; set; } = [];
        public string FullName => $"{FirstName} {LastName}";

    }
    
    public record AddClientRequestModel(
        [Required][RegularExpression(@"^[a-zA-Z]{3,20}$", ErrorMessage = "Name must contain at least 3 lettes")] string FirstName,
        [Required][RegularExpression(@"^[a-zA-Z]{3,20}$", ErrorMessage = "Name must contain at least 3 lettes")] string LastName,
        [Required][RegularExpression(@"^(?=.{13,30}$)[a-z0-9]{3,}@(gmail|hotmail|yahoo)\.com$", ErrorMessage = "Incorrect Email synthax")] string Email,
        [Required][RegularExpression(@"^(?=.{11})0[789][01]\d{8}$")] string PhoneNumber,
        [Required][RegularExpression(@"^(?=.{8,12}$)(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).*$", ErrorMessage = "Password must be 8–12 characters and contain at least one lowercase letter, one uppercase letter, one number, and one special character.")] string Password, 
       [Required]IFormFile Profile);
    public record AddClientResponseModel(Guid Id);
}
