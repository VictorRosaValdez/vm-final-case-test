using AutoMapper;
using DOTNET_Final_Case_BackEnd.DTOs.MessageDTO;
using DOTNET_Final_Case_BackEnd.Models;


namespace DOTNET_Final_Case_BackEnd.Profiles
{
    public class MessageProfile : Profile
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public MessageProfile() 
        {

            // Mapping from the domain object to the readDTO object.
            CreateMap<Message, MessageReadDTO>();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<MessageCreateDTO, Message>().ReverseMap();

            // Mapping from the createDTO object to the domain object. ReverseMap is for navigating both ways.
            CreateMap<MessageUpdateDTO, Message>().ReverseMap();

            // Mapping from the domain object to the deleteDTO object.
            CreateMap<Message, MessageDeleteDTO>();

        }

    }
}
