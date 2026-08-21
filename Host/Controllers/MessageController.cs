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
        public IActionResult Message(AddMessageRequestModel model)
        {

        }
    }
}
