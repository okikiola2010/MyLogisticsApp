using Application.Dtos;
using Application.Interfaces.Repository;
using Application.Interfaces.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ServiceImplementation
{
    public class AuthService(IUserRepository userRepository) : IAuthService
    {
        public async Task<BaseResponse<LoginResponseModel>> Login(LoginRequestModel model)
        {
            var user = await userRepository.Get(model.Email);
            if (user == null) 
            {
                return BaseResponse<LoginResponseModel>.Fail("User not found");
            } 
            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.HashPassword))
            {
                return BaseResponse<LoginResponseModel>.Fail("Invalid credentials");
            }
            if (user.IsDeleted)
            {
                return BaseResponse<LoginResponseModel>.Fail("Account has been deleted");
            }
            if(user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.HashPassword) && !user.IsDeleted)
            {
                AppStatics.CurrentLoginUser = user;
                return BaseResponse<LoginResponseModel>.Sucess(new LoginResponseModel(user.Id, user.Role), "Login Successful.....");
            }
            return BaseResponse<LoginResponseModel>.Fail();
        }
    }
}
