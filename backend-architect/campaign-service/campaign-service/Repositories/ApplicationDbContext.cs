using campaign_service.Models;
using Microsoft.EntityFrameworkCore;

namespace campaign_service.Repositories
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Campaign> Campaign { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasOne(u => u.Role)
                        .WithMany(r => r.Users)
                        .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<Campaign>()
                        .HasOne(c => c.User);
        }
    }
}