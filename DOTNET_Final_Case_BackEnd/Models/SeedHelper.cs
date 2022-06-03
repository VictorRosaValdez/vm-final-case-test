namespace DOTNET_Final_Case_BackEnd.Models
{
    public class SeedHelper
    {
        /// <summary>
        /// Seeded data for Project.
        /// </summary>
        /// <returns>List of projects.</returns>
        public static IEnumerable<Project> GetProjectSeeds()
        {
            var project = new List<Project>()
            {
                new Project(){
                 ProjectId = 1,
                 Title = "The world of .NET",
                 Description = ".NET is an open source platform",
                 Theme = "IT",
                 Industry = "Programming"

                },
                new Project(){
                ProjectId = 2,
                 Title = "Java",
                 Description = "Java is an open source programming language",
                 Theme = "IT",
                 Industry = "Programming"

                },

               new Project(){
                ProjectId = 3,
                Title = "C#",
                Description = "C# an open source programming language",
                Theme = "IT",
                Industry = "Programming"

                }

            };
            return project;
        }

        /// <summary>
        /// Seeded data for User.
        /// </summary>
        /// <returns>List of users.</returns>
        public static IEnumerable<User> GetUserSeeds()
        {
            var user = new List<User>()
            {
                new User(){
                UserId = 1,
                Name = "Leroy",
                Email = "leroy.finalcase@hotmail.com",
                Password = "admin",
                },

                 new User(){
                UserId= 2,
                Name = "Dorine",
                Email = "dorine.finalcase@hotmail.com",
                Password = "admin",
                },

                new User(){
                UserId = 3,
                Name = "Pim",
                Email = "pim.finalcase@hotmail.com",
                Password = "admin",
                },

                 new User(){
                UserId = 4,
                Name = "Victor",
                Email = "victor.finalcase@hotmail.com",
                Password = "admin",
                }

            };
            return user;
        }

        /// <summary>
        /// Seeded data for Skill.
        /// </summary>
        /// <returns>List of skills.</returns>
        public static IEnumerable<Skill> GetSkillSeeds()
        {
            var skill = new List<Skill>()
            {
                new Skill(){
                SkillId = 1,
                Name = "C#"
                
                },

                new Skill(){
                SkillId = 2,
                Name = "Java"

                },

                 new Skill(){
                SkillId = 3,
                Name = "html"

                },


            };
            return skill;
        }

        /// <summary>
        /// Seeded data for SkillProject.
        /// </summary>
        /// <returns>List of skillProjects.</returns>
        public static IEnumerable<SkillProject> GetSkillProjectSeeds()
        {
            var skillProject = new List<SkillProject>()
            {
                new SkillProject(){
                ProjectId = 1,
                SkillId = 1


                  

                },

                new SkillProject(){
                ProjectId = 2,
                SkillId = 2



                },


            };
            return skillProject;
        }

        /// <summary>
        /// Seeded data for SkillUser.
        /// </summary>
        /// <returns>List of skillUsers.</returns>
        public static IEnumerable<SkillUser> GetSkillUSerSeeds()
        {
            var skillUser = new List<SkillUser>()
            {
                new SkillUser(){
                SkillId = 1,
                UserId = 2,




                },

                 new SkillUser(){
                SkillId = 1,
                UserId = 1,




                },

                new SkillUser(){
                SkillId = 3,
                UserId = 4,




                },

                new SkillUser(){
                SkillId = 2,
                UserId = 4,




                },




            };
            return skillUser;
        }

        /// <summary>
        /// Seeded data for ProjectUser.
        /// </summary>
        /// <returns>List of projectUsers.</returns>
        public static IEnumerable<ProjectUser> GetProjectUSerSeeds()
        {
            var projectUser = new List<ProjectUser>()
            {
                new ProjectUser(){
                ProjectId = 1,
                UserId = 2,


                },

                new ProjectUser(){
                ProjectId = 2,
                UserId = 1,


                },






            };
            return projectUser;
        }

      

        /// <summary>
        /// Seeded data for Message.
        /// </summary>
        /// <returns>List of messages.</returns>
        public static IEnumerable<Message> GetMessageSeeds()
        {
            var message = new List<Message>()
            {
                new Message(){
                MessageId = 1,
                ProjectId = 1,
                UserId = 2,
                Description ="Hello World"

                },

                new Message(){
                MessageId = 2,
                ProjectId = 1,
                UserId = 1,
                Description = "Hiiiiiiiii"

                },

                new Message(){
                MessageId= 3,
                ProjectId = 2,
                UserId = 3,
                Description = "It is finished"
                },

                new Message(){
                MessageId =4,
                ProjectId = 1,
                UserId = 4,
                Description = "Well Done!"
                
                }

            };
            return message;
        }
    }
}
