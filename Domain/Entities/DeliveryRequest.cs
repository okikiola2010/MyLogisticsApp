namespace Domain.Entities
{
    public class DeliveryRequest : BaseEntity
    {
        public Guid ClientId { get; set; }
        public Client? Client { get; set; }
        public bool IsUrgent { get; set; }
        public bool IsReady { get; set; } = default!;
        public Guid PickupLocationId { get; set; } = default!;
        public Guid DeliveryLocationId { get; set; } = default!;
        public Location PickupLocation { get; set; } = default!;
        public Location DeliveryLocation { get; set; } = default!;
        public Guid DeliveryId { get; set; }
        public Delivery Delivery { get; set; } = default!;
        public DateTime DateExpected { get; set; }
        public DeliveryRequest(Guid deliveryId, Guid pickupLocationId, Guid deliveryLocationId, Guid clientId, string createdBy, bool isUrgent)
        {
            DeliveryId = deliveryId;
            PickupLocationId = pickupLocationId;
            DeliveryLocationId = deliveryLocationId;
            ClientId = clientId;
            IsUrgent = isUrgent;
            CreatedBy = createdBy;
        }
        public void Update(Guid pickupLocationId, Guid deliveryLocationId, string updateBy, bool isDeleted, bool isReady, bool isUrgent)
        {
            PickupLocationId = pickupLocationId;
            DeliveryLocationId = deliveryLocationId;
            IsReady = isReady;
            UpdatedBy = updateBy;
            IsDeleted = isDeleted;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
