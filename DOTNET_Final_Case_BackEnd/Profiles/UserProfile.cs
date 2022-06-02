using AutoMapper;
using DOTNET_Final_Case_BackEnd.DTOs.UserDTO;
using DOTNET_Final_Case_BackEnd.Models;

namespace DOTNET_Final_Case_BackEnd.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            // Mapping from the domain object to the readDTO object.
            CreateMap<User, UserReadDTO>();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<UserCreateDTO, User>().ReverseMap();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<UserUpdateDTO, User>().ReverseMap();

            // Mapping from the domain object to the deleteDTO object.
            CreateMap<User, UserDeleteDTO>();

        }

    }
}
