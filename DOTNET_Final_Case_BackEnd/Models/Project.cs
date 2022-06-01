
using System.ComponentModel.DataAnnotations;

namespace DOTNET_Final_Case_BackEnd.Models
{
    public class Project
    {
        // Properties
        public int ProjectId { get; set; }
        [MaxLength(60)] public string Title { get; set; }

        [MaxLength(500)] public string Description { get; set; }

        [MaxLength(60)] public string Theme { get; set; }

        [MaxLength(60)] public string Industry { get; set; }

        [MaxLength(500)] public string Link { get; set; }

        [MaxLength(500)] public string Screen { get; set; }

        [MaxLength(500)] public string Photo { get; set; }

        [MaxLength(60)] public string Progress { get; set; }


    }
}
