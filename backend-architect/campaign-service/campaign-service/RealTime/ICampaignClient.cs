namespace campaign_service.RealTime
{
    public interface ICampaignClient
    {
         Task CampaignMessage(string message);
    }
}