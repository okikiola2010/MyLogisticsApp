using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Delivery:BaseEntity
    {
        public bool HasDelivered { get; set; } = default;
        public Guid LgaId { get; set; }
        public int Limit { get; set; } = 10;
        public Lga? Lga { get; set; }
        public bool IsAvailable { get; set; } = true;
        public Guid? DeliveryManId { get; set; }
        public DeliveryMan? DeliveryMan { get; set; }
        public List<DeliveryRequest> Requests { get; set; } = [];

        private Delivery() { }
        public Delivery(Guid lgaId)
        {
            LgaId = lgaId;
        }
        public void Update(bool hasDelivered, Guid lgaId, bool isAvailable, Guid? deliveryManId)
        {
            HasDelivered = hasDelivered;
            LgaId = lgaId;
            IsAvailable = isAvailable;
        }
    }
}
