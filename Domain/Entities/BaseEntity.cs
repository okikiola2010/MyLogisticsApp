namespace Domain.Entities
{
    public class BaseEntity()
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CreatedBy { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; } = default!;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = default;
        public User GetCreator(string createdBy)
        {
            throw new NotImplementedException();
        }
    }
}
