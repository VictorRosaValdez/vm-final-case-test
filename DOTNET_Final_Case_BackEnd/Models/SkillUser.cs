namespace DOTNET_Final_Case_BackEnd.Models
{
    public class SkillUser
    {
        // Properties
        public int SkillId { get; set; }

        // Navigationb property Skill

        public Skill Skill { get; set; }
        public int UserId { get; set; }

        // Navigation property User
        public User User { get; set; }
    }
}
