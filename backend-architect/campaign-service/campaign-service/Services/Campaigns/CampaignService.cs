using campaign_service.dto;
using campaign_service.Repositories;
using campaign_service.Models;
using Microsoft.EntityFrameworkCore;

namespace campaign_service.Services.Campaigns
{
    public class CampaignService : ICampaignService
    {
        private readonly ApplicationDbContext _context;

        public CampaignService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int campaignId)
        {
            var campaign = await _context.Campaign.Where(x => x.Id == campaignId)
                                                .SingleOrDefaultAsync();
            if (campaign == null)
            {
                throw new Exception("Campaign not found to delete");
            }
            _context.Campaign.Remove(campaign);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<GetCampaignResponse>> Get(GetCampaignRequest getCampaignRequest)
        {
            // Start building query with Campaign DbSet
            IQueryable<Campaign> query = _context.Campaign;

            // Apply filters based on criteria
            if (!string.IsNullOrEmpty(getCampaignRequest.Title))
            {
                query = query.Where(c => c.Title.Contains(getCampaignRequest.Title));
            }

            if (!string.IsNullOrEmpty(getCampaignRequest.Description))
            {
                query = query.Where(c => c.Description.Contains(getCampaignRequest.Description));
            }

            if (getCampaignRequest.StartDate != null)
            {
                query = query.Where(c => c.StartDate >= getCampaignRequest.StartDate);
            }

            if (getCampaignRequest.EndDate != null)
            {
                query = query.Where(c => c.EndDate <= getCampaignRequest.EndDate);
            }

            var campaigns = await query
                .Select(c => new GetCampaignResponse
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    UserId = c.UserId
                })
                .ToListAsync();

            return campaigns;
        }

        public async Task<GetCampaignResponse> Save(GetCampaignRequest getCampaignRequest)
        {
            if (getCampaignRequest.StartDate == null || getCampaignRequest.EndDate == null)
            {
                throw new Exception("Start date and end date are required.");
            }

            if (string.IsNullOrWhiteSpace(getCampaignRequest.Title))
            {
                throw new Exception("Title must be filled.");
            }
            // Map GetCampaignRequest to Campaign
            var campaign = new Campaign
            {
                Title = getCampaignRequest.Title ?? string.Empty,
                Description = getCampaignRequest.Description ?? string.Empty,
                StartDate = getCampaignRequest.StartDate.GetValueOrDefault(),
                EndDate = getCampaignRequest.EndDate.GetValueOrDefault(),
                UserId = getCampaignRequest.UserId
            };

            IQueryable<Campaign> query = _context.Campaign;
            query = query.Where(x => x.Title == getCampaignRequest.Title);
            var countCampaignTitle = await query.CountAsync();
            if (countCampaignTitle > 0)
            {
                throw new Exception("Only one campaign can be defined with the same title name");
            }

            _context.Campaign.Add(campaign);
            await _context.SaveChangesAsync();

            var response = new GetCampaignResponse
            {
                Id = campaign.Id,
                Title = campaign.Title,
                Description = campaign.Description,
                StartDate = campaign.StartDate,
                EndDate = campaign.EndDate
            };

            return response;
        }


    }
}