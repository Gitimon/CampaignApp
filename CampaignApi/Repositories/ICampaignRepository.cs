using CampaignApi.Models;

namespace CampaignApi.Repositories
{
    public interface ICampaignRepository
    {
        Task<IEnumerable<Campaign>> GetCampaigns();
        Task<Campaign> AddCampaign(Campaign campaign);
        Task<Campaign> UpdateCampaign(Campaign campaign);
        Task<Campaign?> GetCampaign(int id);
    }
}
