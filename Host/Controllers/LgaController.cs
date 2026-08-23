using Application.Dtos;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LgaController(ILgaService lgaService) : ControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> AddLga(AddLgaRequestModel model)
        {
            var res = await lgaService.AddLga(model);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
        [HttpGet("GetStateLga")]
        public async Task<IActionResult> GetStateLga(Guid stateId)
        {
            var res = await lgaService.GetLgasByStateId(stateId);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
        [HttpGet("GetStateLgaForAdmin")]
        public async Task<IActionResult> GetLgaForStateForAdmin(Guid stateId)
        {
            var res = await lgaService.GetLgasByStateIdForAdmin(stateId);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }

    }
}
