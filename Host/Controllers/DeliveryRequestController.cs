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
        [HttpPost("Add")]
        public async Task<IActionResult> MakeRequest(AddDeliveryReqRequestModel model)
        {
            var res = await deliveryRequestService.CreateRequest(model);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
        [HttpGet("Get/{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var res = await deliveryRequestService.Get(id);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
        [HttpGet("GetCustomerRequests")]
        public async Task<IActionResult> GetRequestsByCustomerId(Guid id)
        {
            var res = await deliveryRequestService.GetCustomerRequests(id);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }

    }
}
