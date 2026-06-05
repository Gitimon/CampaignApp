using CampaignApi.Models;

namespace CampaignApi.Services
{
    public interface ICampaignService
    {
        Task<IEnumerable<Campaign>> GetCampaigns();
        Task<Campaign> AddCampaign(Campaign campaign);
        Task<Campaign?> GetCampaign(int id);
        Task<Campaign> UpdateActiveStatus(Campaign campaign, bool active);
    }
}
