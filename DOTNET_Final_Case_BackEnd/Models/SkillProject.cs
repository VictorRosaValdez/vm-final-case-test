namespace DOTNET_Final_Case_BackEnd.Models
{
    public class SkillProject
    {
        // Properties
        public int ProjectId { get; set; }

        // Navigation property Project
        public Project Project { get; set; }

        public string SkillId { get; set; }

        // Navigation property Skill
        public Skill Skill { get; set; }


    }
}
