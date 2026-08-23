using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Service
{
    public interface ILgaService
    {
        public Task<BaseResponse<AddLgaResponseModel>> AddLga(AddLgaRequestModel model);
        public Task<BaseResponse<Lga?>> Get(Guid id);
        public Task<BaseResponse<List<Lga>>> GetLgasByStateId(Guid stateId);
        public Task<BaseResponse<List<Lga>>> GetLgasByStateIdForAdmin(Guid stateId);
    }
}
