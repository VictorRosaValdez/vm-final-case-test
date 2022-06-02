using System.ComponentModel.DataAnnotations;

namespace DOTNET_Final_Case_BackEnd.DTOs.MessageDTO
{
    public class MessageReadDTO
    {
        // Prperties of the DTO.

        public int MessageId { get; set; }
        [MaxLength(1000)] public string Description { get; set; }
    }
}
