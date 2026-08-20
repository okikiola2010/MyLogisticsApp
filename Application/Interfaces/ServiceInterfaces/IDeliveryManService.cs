using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
