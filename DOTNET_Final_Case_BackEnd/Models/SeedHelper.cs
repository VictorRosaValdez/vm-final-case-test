namespace DOTNET_Final_Case_BackEnd.Models
{
    public class SeedHelper
    {
        public static IEnumerable<Project> GetProjectSeeds()
        {
            var project = new List<Project>()
            {
                new Project(){
                //properties
                },
                new Project(){
                //properties
                }
                
            };
            return project;
        }

        public static IEnumerable<User> GetUserSeeds()
        {
            var user = new List<User>()
            {
                new User(){
                //properties
                },
                new User(){
                //properties
                }

            };
            return user;
        }
    }
}
