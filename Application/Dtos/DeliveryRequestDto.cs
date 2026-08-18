using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class DeliveryRequestDto
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; } = default!;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = default;
        public Guid UserId { get; set; }
        public bool IsUrgent { get; set; }
        public bool IsReady { get; set; } = default!;
        public Guid PickupLocationId { get; set; } = default!;
        public Guid DeliveryLocationId { get; set; } = default!;
        public Location PickupLocation { get; set; } = default!;
        public Location DeliveryLocation { get; set; } = default!;
        public Guid DeliveryId { get; set; }
        public Delivery Delivery { get; set; } = default!;
        public DateTime DateExpected { get; set; }
        
    }
    public record AddDeliveryReqRequestModel(Guid PickUpCommunityId,Guid DeliveryCommunityId, bool IsUrgent);
    public record AddDeliveryReqResponseModel(Guid Id);
}
