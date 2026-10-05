namespace Domain.Entities
{
    public class Message : BaseEntity
    {
        public Guid SenderUserId { get; set; } = default!;
        public User? Sender { get; set; }
        public Guid RecieverUserId { get; set; } = default!;
        public User? Reciever { get; set; }
        public string Context { get; set; } = default!;
        public Message(string context, Guid senderUserId, Guid recieverUserId, string createdBy)
        {
            SenderUserId = senderUserId;
            RecieverUserId = recieverUserId;
            Context = context;
            CreatedBy = createdBy;
        }
        public void Update(string context, Guid senderUserId, Guid recieverUserId, string updatedBy, bool isDeleted)
        {
            Context = context;
            SenderUserId = senderUserId;
            RecieverUserId = recieverUserId;
            IsDeleted = isDeleted;
            UpdatedBy = updatedBy;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
