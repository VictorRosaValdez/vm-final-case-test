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

            // Making the relation with the foreign keys for ProjectUser.
            modelBuilder.Entity<ProjectUser>().HasKey(mgg => new { mgg.ProjectId, mgg.UserId });

            // Making the relation with the foreign keys for SkillProject.
            modelBuilder.Entity<SkillProject>().HasKey(mgg => new { mgg.ProjectId, mgg.SkillId });

            // Making the relation with the foreign keys for SkillUser.
            modelBuilder.Entity<SkillUser>().HasKey(mgg => new { mgg.SkillId, mgg.UserId });


            // Seeded data for projects.
            modelBuilder.Entity<Project>().HasData(SeedHelper.GetProjectSeeds());

            // Seeded data for users.
            modelBuilder.Entity<User>().HasData(SeedHelper.GetUserSeeds());

            // Seeded data for projectUsers.
            modelBuilder.Entity<ProjectUser>().HasData(SeedHelper.GetProjectUSerSeeds());

            // Seeded data for skills.
            modelBuilder.Entity<Skill>().HasData(SeedHelper.GetSkillSeeds());

            // Seeded data for skillProjects.
            modelBuilder.Entity<SkillProject>().HasData(SeedHelper.GetSkillProjectSeeds());

            // Seeded data for skillUsers.
            modelBuilder.Entity<SkillUser>().HasData(SeedHelper.GetSkillUSerSeeds());


            // Seeded data for messages.
            modelBuilder.Entity<Message>().HasData(SeedHelper.GetMessageSeeds());

        }
    }
}
