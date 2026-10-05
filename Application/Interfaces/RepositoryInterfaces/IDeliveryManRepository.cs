using Domain.Entities;

namespace Application.Interfaces.RepositoryInterfaces
{
    public interface IDeliveryManRepository
    {
        public Task Add(DeliveryMan deliveryMan);
        public Task Update(DeliveryMan deliveryMan);
        public Task<DeliveryMan?> Get(Guid id);
        public Task<DeliveryMan?> GetByUserId(Guid userId);
        public Task<DeliveryMan?> Get(string workId);
        public Task<List<DeliveryMan>> GetAll();
    }
}
