using Application.Dtos;
using Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            var res = await authService.Login(model);
            if (res.IsSuccess)
            {
                return Ok(res);
            }
            return BadRequest(res.Message);
        }
    }
}
