using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Service
{
    public interface ICommunityService
    {
        public Task<BaseResponse<AddCommunityResponseModel>> AddCountry(AddCommunityRequestModel model);
        public Task<BaseResponse<Community?>> Get(Guid id);
        public Task<BaseResponse<Community?>> Get(string name);
        public Task<BaseResponse<List<Community>>> GetAll(Guid lgaId);
        public Task<BaseResponse<List<Community>>> GetAllForAdmin(Guid lgaId);
    }
}
