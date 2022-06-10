using DOTNET_Final_Case_BackEnd.DTOs.MessageDTO;
using DOTNET_Final_Case_BackEnd.Interfaces;
using DOTNET_Final_Case_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DOTNET_Final_Case_BackEnd.Dal.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        // Fields

        // Variable for the DbContext.
        private readonly ProjectsDbContext _context;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MessageRepository()
        {
        }

        /// <summary>
        /// Constructor for the messageRepository.
        /// </summary>
        /// <param name="context">Db context</param>
        public MessageRepository(ProjectsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all messages.
        /// </summary>
        /// <returns>A list of message objects.</returns>
        public async Task<ActionResult<IEnumerable<Message>>> GetMessagesAsync()
        {
            // Assign it to the domain object.
            var domainMessages = await _context.Message.ToListAsync();

            return domainMessages;
        }

        /// <summary>
        /// Get a message by ID.
        /// </summary>
        /// <param name="id">Id of the message</param>
        /// <returns>An message object.</returns>
        public async Task<ActionResult<Message>> GetMessageAsync(int id)
        {
            // Assign it to the domain object.
            var domainMessage = await _context.Message.FindAsync(id);

            return domainMessage;
        }

        /// <summary>
        /// Update an message object.
        /// </summary>
        /// <param name="id">Id of the message.</param>
        /// <param name="messageDto">MessageUpdateDTO object.</param>
        /// <returns>An message object.</returns>
        public async Task<ActionResult<Message>> PutMessageAsync(int id, MessageUpdateDTO messageDto)
        {
            // Find the Id.
            var domainMessage = _context.Message.Find(id);

            // Check if the domainMessage is null.
            if (domainMessage == null)
            {
                return null;
            }

            // Update fields.
            domainMessage.Description = messageDto.Description;

            // Saving the update
            await _context.SaveChangesAsync();

            return domainMessage;
        }

        /// <summary>
        /// Create a new message object.
        /// </summary>
        /// <param name="message">message object.</param>
        /// <returns>The new message object.</returns>
        public async Task<ActionResult<Message>> PostMessageAsync(Message message)
        {
            _context.Message.Add(message);
            await _context.SaveChangesAsync();

            return message;
        }

        /// <summary>
        /// Delete an message object.
        /// </summary>
        /// <param name="id">Id of the message object.</param>
        /// <returns>The deleted object.</returns>
        public async Task<ActionResult<Message>> DeleteMessageAsync(int id)
        {
            // Find the Id.
            var domainMessage = await _context.Message.FindAsync(id);

            if (domainMessage == null)
            {
                return null;
            }

            _context.Message.Remove(domainMessage);
            await _context.SaveChangesAsync();

            return domainMessage;
        }

    }
}
