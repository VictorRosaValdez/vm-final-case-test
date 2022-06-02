using System.ComponentModel.DataAnnotations;

namespace DOTNET_Final_Case_BackEnd.Models
{
    public class Message
    {
        // Properties

        public int MessageId { get; set; }

        // Navigation property User
        public int UserId { get; set; }

        // Navigatio property Project
        public int ProjectId { get; set; }
        [MaxLength(1000)] public string Description { get; set; }

    }
}
