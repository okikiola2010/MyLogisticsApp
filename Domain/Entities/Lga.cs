namespace Domain.Entities
{
    public class Lga : BaseEntity
    {
        public Guid StateId { get; set; }
        public State? State { get; set; }
        public string Name { get; set; } = default!;
        public List<Community> Cities { get; set; } = [];
        private Lga() { }
        public Lga(string name, Guid stateId, string createdBy)
        {
            Name = name;
            CreatedBy = createdBy;
            StateId = stateId;
        }
        public void Update(string name, string updatedBy, bool isDeleted, Guid stateId)
        {
            StateId = stateId;
            Name = name;
            IsDeleted = isDeleted;
            UpdatedBy = updatedBy;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
