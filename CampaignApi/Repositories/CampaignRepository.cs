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

        public async Task<Campaign?> GetCampaign(int id)
        {
            return await _context.Campaigns
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Campaign>> GetCampaigns()
        {
            return await _context.Campaigns.ToListAsync();
        }

        public async Task<Campaign> UpdateCampaign(Campaign campaign)
        {
            _context.Update(campaign);
            await _context.SaveChangesAsync();
            return campaign;
        }
    }
}
