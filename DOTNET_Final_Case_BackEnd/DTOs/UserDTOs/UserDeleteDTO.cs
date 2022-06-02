using System.ComponentModel.DataAnnotations;

namespace DOTNET_Final_Case_BackEnd.DTOs.UserDTO
{
    public class UserDeleteDTO
    {
        // Prperties of the DTO.
        public int UserId { get; set; }
        [MaxLength(60)] public string Name { get; set; }
       

        

    }
}
