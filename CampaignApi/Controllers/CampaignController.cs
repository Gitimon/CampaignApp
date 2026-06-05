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
            await _campaignService.AddCampaign(campaign);
            return Created();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campaign>>> GetCampaigns()
        {
            var campaigns = await _campaignService.GetCampaigns();
            return Ok(campaigns);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateActiveStatus(int id, bool active)
        {
            var campaign = await _campaignService.GetCampaign(id);

            if (campaign is null)
            {
                return NotFound();
            }

            await _campaignService.UpdateActiveStatus(campaign, active);
            return NoContent();
        }
    }
}
