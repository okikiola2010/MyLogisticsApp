using Application.Dtos;
using Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController(IMessageService messageService) : ControllerBase
    {
        [HttpPost("AddMessage")]
        public async Task<IActionResult> Message(AddMessageRequestModel model)
        {
            var res = await messageService.AddMessage(model);
            return res.IsSuccess ? Ok(res ) : BadRequest(res); 
        }
    }
}
