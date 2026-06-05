using CampaignApi.Models;

namespace CampaignApi.Services
{
    public interface ICampaignService
    {
        Task<IEnumerable<Campaign>> GetCampaigns();
        Task<Campaign> AddCampaign(Campaign campaign);
    }
}
