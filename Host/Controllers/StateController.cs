using Application.Dtos;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController(IStateService stateService) : ControllerBase
    {
        [HttpPost("AddState")]
        public async Task<IActionResult> AddState(AddStateRequestModel model)
        {
            var res = await stateService.AddState(model);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
        [HttpGet("Get/{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var res = await stateService.GetState(id);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var res = await stateService.GetAll();
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
        [HttpGet("GetAllForAdmin")]
        public async Task<IActionResult> GetAllForAdmin()
        {
            var res = await stateService.GetAllForAdmin();
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
    }
}
