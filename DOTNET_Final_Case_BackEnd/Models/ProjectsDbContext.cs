using Microsoft.EntityFrameworkCore;

namespace DOTNET_Final_Case_BackEnd.Models
{
    public class ProjectsDbContext : DbContext
    {
        public ProjectsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Project { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(SeedHelper.GetProjectSeeds());
            modelBuilder.Entity<User>().HasData(SeedHelper.GetUserSeeds());
        }
    }
}
