using DOTNET_Final_Case_BackEnd.DTOs.MessageDTO;
using DOTNET_Final_Case_BackEnd.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Final_Case_BackEnd.Dal.Repositories
{
    public class MessageRepository : IMessageRepository
    {
    
        public Task<ActionResult<MessageDeleteDTO>> DeleteMessageAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<MessageReadDTO>> GetMessageAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<MessageReadDTO>>> GetMessagesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<MessageReadDTO>> PostMessageAsync(MessageCreateDTO messageDto)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<MessageUpdateDTO>> PutMessageAsync(int id, MessageUpdateDTO messageDto)
        {
            throw new NotImplementedException();
        }
    }
}
