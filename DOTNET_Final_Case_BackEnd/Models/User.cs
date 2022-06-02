using System.ComponentModel.DataAnnotations;

namespace DOTNET_Final_Case_BackEnd.Models
{
    public class User
    {
        // Properties
        public int UserId { get; set; }
        public bool Hidden { get; set; }
        [MaxLength(60)] public string Name { get; set; }
        [MaxLength(100)] public string Email { get; set; }
        [MaxLength(60)] public string Password { get; set; }

        [MaxLength(500)] public string? Portfolio { get; set; }

        [MaxLength(1000)] public string? Description { get; set; }

        // Navigation Property
        public ICollection<Message> Message { get; set; }

    }
}
