using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.RepositoryInterfaces
{
    public interface IDeliveryRequestRepository
    {
        public Task Add(DeliveryRequest deliveryRequest);
        public Task Update(DeliveryRequest deliveryRequest);
        public Task<DeliveryRequest?> Get(Guid id);
        public Task<List<DeliveryRequest>> GetByCustomerId(Guid customerId);
        public Task<List<DeliveryRequest>> GetAll();
    }
}
