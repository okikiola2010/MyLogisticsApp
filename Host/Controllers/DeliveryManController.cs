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
        [HttpPost("Add")]
        public async Task<IActionResult> AddDeliveryMan(AddDeliverManRequestModel model)
        {
            var res = await deliveryManService.AddDeliveryMan(model);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
        [HttpGet("Get/id/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var res = await deliveryManService.Get(id);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
        [HttpGet("WorkId")]
        public async Task<IActionResult> Get(string workId)
        {
            var res = await deliveryManService.Get(workId);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
        [HttpGet("AllDeliveryMen")]
        public async Task<IActionResult> GetAll()
        {
            var res = await deliveryManService.GetAll();
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
    }
}
