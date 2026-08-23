using Application.Dtos;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityController(ICommunityService communityService) : ControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> AddCommunity(AddCommunityRequestModel model)
        {
            var res = await communityService.AddCountry(model);
            return res.IsSuccess ? Ok(res) : BadRequest(res); 
        }
        [HttpGet("AdminGetByLga")]
        public async Task<IActionResult> GetCommunitiesForLgaForAdmin(Guid lgaId)
        {
            var res = await communityService.GetAllForAdmin(lgaId);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
        [HttpGet("GetByLga")]
        public async Task<IActionResult> GetCommunitiesForLga(Guid lgaId)
        {
            var res = await communityService.GetAll(lgaId);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetCommunity(Guid lgaId)
        {
            var res = await communityService.GetAll(lgaId);
            return res.IsSuccess ? Ok(res) : BadRequest(res);
        }

    }
}
