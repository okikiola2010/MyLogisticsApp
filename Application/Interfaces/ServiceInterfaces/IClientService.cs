using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface IClientService
    {
        public Task<BaseResponse<AddClientResponseModel>> AddClient(AddClientRequestModel model);
        public Task<BaseResponse<ClientDto>> GetClient(Guid id);
        public Task<BaseResponse<ClientDto>> GetClient(string phonenumber);
        public Task<BaseResponse<List<ClientDto>>> GetAll();
    }
}
