using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.ServiceInterfaces
{
    public interface IAuthService
    {
        public Task<BaseResponse<LoginResponseModel>> Login(LoginRequestModel model);
    }
}
