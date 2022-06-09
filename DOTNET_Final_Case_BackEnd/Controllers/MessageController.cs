using AutoMapper;
using DOTNET_Final_Case_BackEnd.Dal.Repositories;
using DOTNET_Final_Case_BackEnd.DTOs.MessageDTO;
using DOTNET_Final_Case_BackEnd.Interfaces;
using DOTNET_Final_Case_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace DOTNET_Final_Case_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class MessageController : ControllerBase
    {
        // Private field
        private readonly IMessageRepository _message;

        // Variable mapper for mapping the DTOs.
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor of the message.
        /// </summary>
        /// <param name="message"></param>
        public MessageController(IMessageRepository message, IMapper mapper)
        {

            _message = message;
            _mapper = mapper;
        }

        // GET: api/messages
        /// <summary>
        /// Get all messages.
        /// </summary>
        /// <response code="200">Succesfully returns a list of message objects.</response>
        /// <returns>A list of message objects.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageReadDTO>>> GetMessages()
        {
            // Instance of the domainMessages objects.
            var domainMessages = await _message.GetMessagesAsync();

            // Map domainMessages with messageReadDTO
            var dtoMessage = _mapper.Map<List<MessageReadDTO>>(domainMessages.Value);

            return dtoMessage;
        }

        /// <summary>
        /// Get a message by ID.
        /// </summary>
        /// <param name="id">Id of the message.</param>
        /// <returns>A messageDto object.</returns>
        /// <response code="200">Succesfully returns a message object.</response>
        /// <response code="400">Error: Response with this is a bad request.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageReadDTO>> GetMessage(int id)
        {
            // Instance of the domainMessage objects.
            var domainMessage = await _message.GetMessageAsync(id);

            // Map domainProject with messageReadDTO
            var dtoMessage = _mapper.Map<MessageReadDTO>(domainMessage.Value);

            if (dtoMessage == null)
            {
                return NotFound();
            }
            return dtoMessage;
        }

        // PUT: api/messages/5
        /// <summary>
        /// Update a message.
        /// </summary>
        /// <param name="id">Id of the message</param>
        /// <param name="messageDto">messageDto</param>
        /// <returns></returns>
        /// <response code="204">Succesfully object updated.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult<MessageUpdateDTO>> PutMessage(int id, MessageUpdateDTO messageDto)
        {
            // Intance of the messageRepository
            MessageRepository messageRepository = new();

            // Instance of the domainMessage objects.
            var domainMessage = await _message.PutMessageAsync(id, messageDto);

            // Map domainProject with messageReadDTO
            var dtoMessage = _mapper.Map<MessageUpdateDTO>(domainMessage.Value);

            try
            {
                await _message.PutMessageAsync(id, messageDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!messageRepository.MessageExists(dtoMessage.MessageId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }


        // POST: api/messages
        /// <summary>
        /// Create a message object.
        /// </summary>
        /// <param name="messageDto"></param>
        /// <returns>The created messageDto object.</returns>
        /// <response code="201">Succesfully object created.</response>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<MessageReadDTO>> PostMessage(MessageCreateDTO messageDto)
        {
            // Map domainMessage with MessageCreateDTO
            var domainMessage = _mapper.Map<Message>(messageDto);

            // New message object.
            await _message.PostMessageAsync(domainMessage);

            // Get Movie Id for new movie object.
            int messageId = _message.PostMessageAsync(domainMessage).Id;

            // Returning the new message.
            return CreatedAtAction("GetMessage", new { id = messageId }, messageDto);
        }

        /// <summary>
        /// Delete a message by Id.
        /// </summary>
        /// <param name="id">Id of the messageDto object.</param>
        /// <returns></returns>
        /// <response code="204">Succesfully object deleted.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<ActionResult<MessageDeleteDTO>> DeleteMessageAsync(int id)
        {
            // Instance of the domainMessage objects.
            var domainMessage = await _message.DeleteMessageAsync(id);

            // Map messageDeleteDTO with domainMessage.
            var dtoMessage = _mapper.Map<MessageDeleteDTO>(domainMessage.Value);

            if (dtoMessage == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
