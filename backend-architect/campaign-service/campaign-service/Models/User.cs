using System.ComponentModel.DataAnnotations.Schema;

namespace campaign_service.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; } 
        public required Role Role { get; set; }
        
        [ForeignKey("Role")]
        public required int RoleId { get; set; }
    }
}