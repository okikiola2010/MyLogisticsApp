using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface IMessageService
    {
        public Task<BaseResponse<AddMessageResponseModel>> AddMessage(AddMessageRequestModel message);
        public Task<BaseResponse<List<string>>> GetClientMessageLink(Guid clientId);
        public Task<BaseResponse<List<Message>>> GetBtwTwoUsers(Guid firstPerson, Guid secondPerson);
        public Task<BaseResponse<List<string>>> GetDeliveryMessageLink(Guid deliveryManId);
    }
}
