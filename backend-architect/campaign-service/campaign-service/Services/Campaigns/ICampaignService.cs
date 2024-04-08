using campaign_service.dto;

namespace campaign_service.Services.Campaigns
{
    public interface ICampaignService
    {
        Task<IEnumerable<GetCampaignResponse>> Get(GetCampaignRequest getCampaignRequest);
        Task<GetCampaignResponse> Save(GetCampaignRequest getCampaignRequest);
        Task<bool> Delete(int campaignId);
    }
}