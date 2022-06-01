using System.ComponentModel.DataAnnotations;

namespace DOTNET_Final_Case_BackEnd.Models
{
    public class Message
    {
        // Properties

        public int MessageId { get; set; }

        // Navigation property Chat
        public Chat Chat { get; set; }

        public string UserId { get; set; }

        // Navigation property User
        public User User { get; set; }

        [MaxLength(1000)] public string Description { get; set; }

    }
}
