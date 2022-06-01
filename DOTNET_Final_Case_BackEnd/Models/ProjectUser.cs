namespace DOTNET_Final_Case_BackEnd.Models
{
    public class ProjectUser
    {
        // Properties
        public int ProjectId { get; set; }

        // Navigation property
        public  Project Project { get; set; }
        public int UsertId { get; set; }

        // Navigation property
        public User User { get; set; }

        public bool IsOwner { get; set; }
    }
}
