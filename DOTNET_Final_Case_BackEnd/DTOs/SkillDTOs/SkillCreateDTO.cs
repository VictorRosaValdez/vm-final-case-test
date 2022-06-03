using System.ComponentModel.DataAnnotations;

namespace DOTNET_Final_Case_BackEnd.DTOs.SkillDTO
{
    public class SkillCreateDTO
    {
        // Prperties of the DTO.
        [MaxLength(60)] public string Name { get; set; }
    }
}
