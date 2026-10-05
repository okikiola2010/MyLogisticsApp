using Application.Dtos;
using Application.Interfaces.ServiceInterfaces;
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
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
        [HttpGet("GetClientMessageLinks/{clientId}")]
        public async Task<IActionResult> GetClientMessageConnection(Guid clientId)
        {
            var res = await messageService.GetClientMessageLink(clientId);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
        [HttpGet("GetDeliveryManMessageLinks/{deliveryManId:guid}")]
        public async Task<IActionResult> GetDeliveryManMessageConnection(Guid deliveryManId)
        {
            var res = await messageService.GetDeliveryMessageLink(deliveryManId);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
        [HttpGet("GetMessageBtwTwoUser/{firstUserId:guid}/{secondUserId:guid}")]
        public async Task<IActionResult> GetMessage(Guid firstUserId,Guid secondUserId)
        {
            var res = await messageService.GetBtwTwoUsers(firstUserId,secondUserId);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
    }
}
