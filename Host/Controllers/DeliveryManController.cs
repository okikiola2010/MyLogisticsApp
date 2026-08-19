using Application.Dtos;
using Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryManController(IDeliveryManService deliveryManService) : ControllerBase
    {
        [HttpPost("DeliveryMan")]
        public async Task<IActionResult> AddDeliveryMan(AddDeliverManRequestModel model)
        {
            var res = await deliveryManService.AddDeliveryMan(model);
            return res.IsSuccess ? Ok(res) : BadRequest(res.Message);
        }
        [HttpGet("DeliveryMan/id/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var res = await deliveryManService.Get(id);
            return res.IsSuccess ? Ok(res) : BadRequest(res.Message);
        }
        [HttpGet("DeliveryMan/WorkId")]
        public async Task<IActionResult> Get(string workId)
        {
            var res = await deliveryManService.Get(workId);
            return res.IsSuccess ? Ok(res) : BadRequest(res.Message);
        }
        [HttpGet("Delivery/AllDeliveryMen")]
        public async Task<IActionResult> GetAll()
        {
            var res = await deliveryManService.GetAll();
            return res.IsSuccess ? Ok(res) : BadRequest(res.Message);
        }
    }
}
