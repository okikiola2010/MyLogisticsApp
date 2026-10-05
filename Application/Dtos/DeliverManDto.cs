using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class DeliverManDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public string FirstName { get; set; } = default!;
        public IFormFile Profile { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public string WorkId { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string MiniTime { get; set; } = default!;
        public DateTime LastTimeOrdered { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public List<Delivery> DeliverManDeliveries { get; set; } = new List<Delivery>();
    }
    public record AddDeliverManRequestModel(
       [Required][RegularExpression(@"^[a-zA-Z]{3,20}$",ErrorMessage = "Name must contain at least 3 lettes")] string FirstName,
       [Required][RegularExpression(@"^[a-zA-Z]{3,20}$", ErrorMessage = "Name must contain at least 3 lettes")] string LastName,
       [Required][RegularExpression(@"(?=.{13,30})^[a-z]{3,}@(gmail|hotmail|yahoo).com$",ErrorMessage = "Incorrect Email synthax")] string Email,
       [Required][RegularExpression(@"^(?=.{8,12}$)(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).*$",ErrorMessage = "Password must be 8–12 characters and contain at least one lowercase letter, one uppercase letter, one number, and one special character.")] string Password,
       [Required] IFormFile Profile);
    public record AddDeliverManResponseModel(Guid Id);
}
