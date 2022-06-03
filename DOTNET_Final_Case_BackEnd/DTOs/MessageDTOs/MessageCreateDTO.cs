using System.ComponentModel.DataAnnotations;

namespace DOTNET_Final_Case_BackEnd.DTOs.MessageDTO
{
    public class MessageCreateDTO
    {
        // Prperties of the DTO.
        [MaxLength(1000)] public string Description { get; set; }
    }
}
