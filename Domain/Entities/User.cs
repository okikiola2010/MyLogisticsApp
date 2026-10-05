namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = default!;
        public string HashPassword { get; set; } = default!;
        public string Role { get; set; } = default!;
        private User() { }
        public User(string email, string password, string role)
        {
            Email = email;
            HashPassword = password;
            Role = role;
            CreatedBy = Id.ToString();
        }
        public void Update(string email, string hashPassword, string updateBy, bool isDeleted)
        {
            Email = email;
            HashPassword = hashPassword;
            UpdatedBy = updateBy;
            IsDeleted = isDeleted;
            UpdatedAt = DateTime.UtcNow;
        }

    }
}
