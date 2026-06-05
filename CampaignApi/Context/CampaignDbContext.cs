using CampaignApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CampaignApi.Context
{
    public class CampaignDbContext :DbContext
    {
        public DbSet<Campaign> Campaigns { get; set; }

        public CampaignDbContext(DbContextOptions<CampaignDbContext> options) : base(options)
        {
        }
    }
}
