using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface IDeliveryRequestService
    {
        public Task<BaseResponse<AddDeliveryReqResponseModel?>> CreateRequest(AddDeliveryReqRequestModel model);
    }
}
