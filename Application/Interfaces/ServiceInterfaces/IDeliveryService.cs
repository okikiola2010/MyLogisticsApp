using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface IDeliveryService
    {
        public Task ProcessPendingDelivery();
    }
}
