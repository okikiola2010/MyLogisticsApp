using Application.Dtos;
using Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryRequestController(IDeliveryRequestService deliveryRequestService) : ControllerBase
    {
        [HttpPost("DeliveryRequest/Add")]
        public async Task<IActionResult> MakeRequest(AddDeliveryReqRequestModel model)
        {
            var res = await deliveryRequestService.CreateRequest(model);
            return res.IsSuccess ? Ok(res) : BadRequest(res.Message);
        }
        public 
    }
}
