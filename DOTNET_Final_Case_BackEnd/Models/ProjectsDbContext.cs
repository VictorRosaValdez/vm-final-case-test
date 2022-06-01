using Microsoft.EntityFrameworkCore;

namespace DOTNET_Final_Case_BackEnd.Models
{
    public class ProjectsDbContext : DbContext
    {
       
        // Properties for creating the tables in the SSMS with the EF.

        // Table of Project
        public DbSet<Project> Project { get; set; }
        
        // Table of User
        public DbSet<User> User { get; set; }

        // Table of ProjectUser
        public DbSet<ProjectUser> ProjectUser { get; set; }

        // Table of Skill
        public DbSet<Skill> Skill { get; set; }

        // Table of SkillProject
        public DbSet<SkillProject> SkillProject { get; set; }

        // Table of SkillUser
        public DbSet<SkillUser> SkillsUser { get; set; }

        // Table of Chat
        public DbSet<Chat> Chat { get; set; }

        // Table of Message

        public DbSet<Message> Message { get; set; }

        /// <summary>
        /// Constructor for the use of the connection string in the Startup.cs
        /// </summary>
        /// <param name="options"></param>
        public ProjectsDbContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(SeedHelper.GetProjectSeeds());
            modelBuilder.Entity<User>().HasData(SeedHelper.GetUserSeeds());
        }
    }
}
