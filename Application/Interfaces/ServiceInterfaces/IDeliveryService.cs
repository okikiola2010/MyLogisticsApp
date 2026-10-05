using Domain.Entities;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface IDeliveryService
    {
        public Task ProcessPendingDelivery();
        public Task<BaseResponse<List<Delivery>>> GetUndoneDeliveryManWork(Guid deliveryManId);

    }
}
