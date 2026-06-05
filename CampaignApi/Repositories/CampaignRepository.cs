using CampaignApi.Context;
using CampaignApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CampaignApi.Repositories
{
    public class CampaignRepository(
        CampaignDbContext context) : ICampaignRepository
    {
        private readonly CampaignDbContext _context = context;

        public async Task<Campaign> AddCampaign(Campaign campaign)
        {
            await _context.AddAsync(campaign);
            await _context.SaveChangesAsync();
            return campaign;
        }

        public async Task<IEnumerable<Campaign>> GetCampaigns()
        {
            return await _context.Campaigns.ToListAsync();
        }
    }
}
