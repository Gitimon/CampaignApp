using CampaignApi.Models;
using CampaignApi.Repositories;

namespace CampaignApi.Services
{
    public class CampaignService(
        ICampaignRepository campaignRepository) : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository = campaignRepository;

        public async Task<Campaign> AddCampaign(Campaign campaign)
        {
            return await _campaignRepository.AddCampaign(campaign);
        }

        public async Task<IEnumerable<Campaign>> GetCampaigns()
        {
            return await _campaignRepository.GetCampaigns();
        }
    }
}
