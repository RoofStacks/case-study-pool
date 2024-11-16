namespace campaign_service.dto
{
    public class GetCampaignRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int UserId { get; set; }
    }
}