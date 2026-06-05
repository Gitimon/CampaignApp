using CampaignApi.Models;

namespace CampaignApi.Repositories
{
    public interface ICampaignRepository
    {
        Task<IEnumerable<Campaign>> GetCampaigns();
        Task<Campaign> AddCampaign(Campaign campaign);
    }
}
