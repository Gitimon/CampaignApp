using CampaignApi.Models;
using CampaignApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CampaignApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampaignController(
        ICampaignService campaignService) : ControllerBase
    {
        private readonly ICampaignService _campaignService = campaignService;

        [HttpPost]
        public async Task<IActionResult> AddCampaign(Campaign campaign)
        {
            var result = _campaignService.AddCampaign(campaign);
            return Created();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campaign>>> GetCampaigns()
        {
            var campaigns = await _campaignService.GetCampaigns();
            return Ok(campaigns);
        }
    }
}
