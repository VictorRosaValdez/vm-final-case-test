using AutoMapper;
using DOTNET_Final_Case_BackEnd.DTOs.SkillDTO;
using DOTNET_Final_Case_BackEnd.Models;

namespace DOTNET_Final_Case_BackEnd.Profiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {

            // Mapping from the domain object to the readDTO object.
            CreateMap<Skill, SkillReadDTO>();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<SkillCreateDTO, Skill>().ReverseMap();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<SkillUpdateDTO, Skill>().ReverseMap();

            // Mapping from the domain object to the deleteDTO object.
            CreateMap<Skill, SkillDeleteDTO>();

        }
    }
}
