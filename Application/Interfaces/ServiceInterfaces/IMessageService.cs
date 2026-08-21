using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface IMessageService
    {
        public Task<BaseResponse<AddMessageResponseModel>> AddMessage(AddMessageRequestModel message);
        public Task<BaseResponse<List<string>>> GetClientMessageLink(Guid clientId);
        public Task<BaseResponse<List<string>>> GetDeliveryMessageLink(Guid deliveryManId);
    }
}
