namespace campaign_service.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public required Role Role { get; set; }
    }
}