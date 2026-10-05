using Application.Dtos;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface IClientService
    {
        public Task<BaseResponse<AddClientResponseModel>> AddClient(AddClientRequestModel model);
        public Task<BaseResponse<ClientDto>> GetClient(Guid id);
        public Task<BaseResponse<ClientDto>> GetClientByUserId(Guid userId);
        public Task<BaseResponse<ClientDto>> GetClient(string phonenumber);
        public Task<BaseResponse<List<ClientDto>>> GetAll();
    }
}
