using Application.Dtos;
using Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController(IClientService clientService) : ControllerBase
    {
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromForm] AddClientRequestModel model)
        {
            var res = await clientService.AddClient(model);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
        [HttpGet("GetById/{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var res = await clientService.GetClient(id);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
        [HttpGet("GetByUserId/{userId:guid}")]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            var res = await clientService.GetClientByUserId(userId);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }

        [HttpGet("GetByPhonenumber/{phonenumber}")]
        public async Task<IActionResult> Get(string phonenumber)
        {
            var res = await clientService.GetClient(phonenumber);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
        [HttpGet("Get/All")]
        public async Task<IActionResult> GetAll()
        {
            var res = await clientService.GetAll();
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
    }
}

