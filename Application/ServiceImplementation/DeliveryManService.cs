using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.RepositoryInterfaces;
using Application.Interfaces.ServiceInterfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ServiceImplementation
{
    internal class DeliveryManService(IDeliveryManRepository deliveryManRepository,IUnitOfWork unitOfWork) : IDeliveryManService
    {
        public Task<BaseResponse<AddDeliverManResponseModel>> AddDeliveryMan(AddDeliverManRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<DeliverManDto>> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<DeliverManDto>> Get(string workId)
        {
            throw new NotImplementedException();
        }
       

        public Task<BaseResponse<List<DeliverManDto>>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
