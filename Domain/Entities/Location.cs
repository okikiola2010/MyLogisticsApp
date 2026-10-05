namespace Domain.Entities
{
    public class Location : BaseEntity
    {
        public Guid StateId { get; set; }
        public Guid LgaId { get; set; }
        public Guid CommunityId { get; set; }
        public State State { get; set; } = default!;
        public Lga Lga { get; set; } = default!;
        public Community Community { get; set; } = default!;
        public string FullAddress => $"{State.Name},{Lga.Name},{Community.Name}";
        private Location() { }
        public Location(Guid stateId, Guid lgaId, Guid communityId, string createdBy)
        {
            CommunityId = communityId;
            StateId = stateId;
            LgaId = lgaId;
            CreatedBy = createdBy;
        }
        Location a = new Location() { };

        public void Update(Guid stateId, Guid lgaId, Guid communityId, string updatedBy, bool isDeleted)
        {
            CommunityId = communityId;
            StateId = stateId;
            LgaId = lgaId;
            IsDeleted = isDeleted;
            UpdatedBy = updatedBy;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
