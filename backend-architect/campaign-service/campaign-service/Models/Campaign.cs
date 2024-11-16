using System.ComponentModel.DataAnnotations.Schema;

namespace campaign_service.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }

}