using System.ComponentModel.DataAnnotations;

namespace DOTNET_Final_Case_BackEnd.Models
{
    public class Skill
    {
        // Properties
        public int SkillId { get; set; }
        [MaxLength(60)]public string Name { get; set; }
    }
}
