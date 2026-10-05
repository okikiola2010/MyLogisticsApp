using Application.Dtos;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface IDeliveryManService
    {
        public Task<BaseResponse<AddDeliverManResponseModel>> AddDeliveryMan(AddDeliverManRequestModel model);
        public Task<BaseResponse<DeliverManDto>> Get(Guid id);
        public Task<BaseResponse<DeliverManDto>> Get(string workId);
        public Task<BaseResponse<List<DeliverManDto>>> GetAll();
    }
}
