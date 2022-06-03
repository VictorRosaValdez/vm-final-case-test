using System.ComponentModel.DataAnnotations;

namespace DOTNET_Final_Case_BackEnd.DTOs.ProjectDTO
{
    public class ProjectDeleteDTO
    {
        // Prperties of the DTO.

        public int ProjectId { get; set; }
        [MaxLength(60)] public string Title { get; set; }

    }
}
