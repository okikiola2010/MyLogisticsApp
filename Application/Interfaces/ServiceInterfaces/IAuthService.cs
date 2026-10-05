using Application.Dtos;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface IAuthService
    {
        public Task<BaseResponse<LoginResponseModel>> Login(LoginRequestModel model);
    }
}
