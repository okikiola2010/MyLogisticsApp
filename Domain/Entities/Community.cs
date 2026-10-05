namespace Domain.Entities
{
    public class Community : BaseEntity
    {
        public Guid LgaId { get; set; }
        public Lga? Lga { get; set; }
        public string Name { get; set; } = default!;
        private Community() { }
        public Community(string name, Guid lgaId, string createdBy)
        {
            Name = name;
            CreatedBy = createdBy;
            LgaId = lgaId;
        }
        public void Update(string name, string updatedBy, bool isDeleted, Guid lgaId)
        {
            LgaId = lgaId;
            Name = name;
            IsDeleted = isDeleted;
            UpdatedBy = updatedBy;
            UpdatedAt = DateTime.UtcNow;
        }

    }
}
