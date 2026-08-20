using Application.Dtos;
using Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController(IClientService clientService) : ControllerBase
    {
        [HttpPost("Client/SignUp")]
        public async Task<IActionResult> SignUp(AddClientRequestModel model)
        {
            var res = await clientService.AddClient(model);
            return res.IsSuccess ? Ok(res) : BadRequest(res.Message);
        }
        [HttpGet("Client/Get/id/{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var res = await clientService.GetClient(id);
            return res.IsSuccess ? Ok(res) : BadRequest(res.Message);
        }

        [HttpGet("Client/Get/Phonenumber")]
        public async Task<IActionResult> Get(string  phonenumber)
        {
            var res = await clientService.GetClient(phonenumber);
            return res.IsSuccess ? Ok(res) : BadRequest(res.Message);
        }
        [HttpGet("Client/Get/All")]
        public async Task<IActionResult> GetAll()
        {
            var res = await clientService.GetAll();
            return res.IsSuccess ? Ok(res) : BadRequest(res.Message);
        }

    }
}

