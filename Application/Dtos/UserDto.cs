using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; } = default!;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = default;
        public string Email { get; set; } = default!;
        public string HashPassword { get; set; } = default!;
        public string Role { get; set; } = default!;
    }
    public record LoginRequestModel(string Email, string Password);
    public record LoginResponseModel(Guid Id, string Role);
}
