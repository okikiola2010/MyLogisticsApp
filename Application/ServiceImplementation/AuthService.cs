using Application.Dtos;
using Application.Interfaces.Repository;
using Application.Interfaces.ServiceInterfaces;

namespace Application.ServiceImplementation
{
    public class AuthService(IUserRepository userRepository, IJwtService jwtService) : IAuthService
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
            if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.HashPassword) && !user.IsDeleted)
            {
                return BaseResponse<LoginResponseModel>.Sucess(new LoginResponseModel(user.Id, user.Role, jwtService.GenerateToken(user)), "Login Successful.....");
            }
            return BaseResponse<LoginResponseModel>.Fail();
        }
    }
}
