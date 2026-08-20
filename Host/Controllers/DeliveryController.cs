using Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController(IDeliveryService deliveryService) : ControllerBase
    {
        public async Task<IActionResult> GetUndoneDeliveryManWork(Guid id)
        {
            var res = await deliveryService.GetUndoneDeliveryManWork(id);
            return res.IsSuccess ?  Ok(res) : BadRequest(res);
        }
    }
}
