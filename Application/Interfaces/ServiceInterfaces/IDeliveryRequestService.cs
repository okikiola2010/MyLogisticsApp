using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface IDeliveryRequestService
    {
        public Task<BaseResponse<AddDeliveryReqResponseModel?>> CreateRequest(AddDeliveryReqRequestModel model);
        public Task<BaseResponse<DeliveryRequest>> Get(Guid id);
        public Task<BaseResponse<List<DeliveryRequest>>> GetCustomerRequests(Guid clientId);

    }
}
