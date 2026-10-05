using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces.Service
{
    public interface IStateService
    {
        public Task<BaseResponse<AddStateResponseModel>> AddState(AddStateRequestModel model);
        public Task<BaseResponse<State?>> GetState(Guid id);
        public Task<BaseResponse<State?>> GetState(string name);
        public Task<BaseResponse<List<State>>> GetAll();
        public Task<BaseResponse<List<State>>> GetAllForAdmin();
    }
}
