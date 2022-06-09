using System.ComponentModel.DataAnnotations;

namespace DOTNET_Final_Case_BackEnd.DTOs.SkillDTO
{
    public class SkillReadDTO
    {
        // Prperties of the DTO.
        public int SkillId { get; set; }
        [MaxLength(60)] public string Name { get; set; }
    }
}
