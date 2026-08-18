using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.RepositoryInterfaces
{
    public  interface IDeliveryRepository
    {
        public Task Add(Delivery delivery);
        public Task Update(Delivery delivery);
        public Task<Delivery?> Get(Guid id);
        public Task<List<Delivery>> GetAll();
    }
}
