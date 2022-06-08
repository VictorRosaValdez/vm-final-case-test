using DOTNET_Final_Case_BackEnd.DTOs.UserDTO;
using DOTNET_Final_Case_BackEnd.Interfaces;
using DOTNET_Final_Case_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DOTNET_Final_Case_BackEnd.Dal.Repositories
{
    public class UserRepository : IUserRepository
    {
        // Fields

        // Variable for the DbContext.
        private readonly ProjectsDbContext _context;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public UserRepository()
        {
        }

        /// <summary>
        /// Constructor for the ProjectRepository.
        /// </summary>
        /// <param name="context">Db context</param>
        public UserRepository(ProjectsDbContext context)
        {
            _context = context;

        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns>A list of user objects.</returns>
        public async Task<ActionResult<IEnumerable<User>>> GetUsersAsync()
        {
                // Assign it to the domain object.
                var domainUsers = await _context.User.ToListAsync();

                return domainUsers;
            
        }

        /// <summary>
        /// Get a user by ID.
        /// </summary>
        /// <param name="id">Id of the user</param>
        /// <returns>An user object.</returns>
        public async Task<ActionResult<User>> GetUserAsync(int id)
        {
            // Assign it to the domain object.
            var domainUser = await _context.User.FindAsync(id);

            return domainUser;
        }

        /// <summary>
        /// Update an user object.
        /// </summary>
        /// <param name="id">Id of the user.</param>
        /// <param name="userDto">UserUpdateDTO object.</param>
        /// <returns>An user object.</returns>
        public async Task<ActionResult<User>> PutUserAsync(int id, UserUpdateDTO userDto)
        {
            // Find the Id.
            var domainUser = _context.User.Find(id);

            // Check if the domainUser is null.
            if (domainUser == null)
            {
                return domainUser;
            }

            // Update fields.
            domainUser.Name = userDto.Name;
            domainUser.Email = userDto.Email;
            domainUser.Portfolio = userDto.Portfolio;
            domainUser.Description = userDto.Description;

            // Saving the update
            await _context.SaveChangesAsync();

            return domainUser;
        }

        /// <summary>
        /// Create a new user object.
        /// </summary>
        /// <param name="user">User object.</param>
        /// <returns>The new user object.</returns>
        public async Task<ActionResult<User>> PostUserAsync(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return user;

        }

        /// <summary>
        /// Delete an user object.
        /// </summary>
        /// <param name="id">Id of the user object.</param>
        /// <returns>The deleted object.</returns>
        public async Task<ActionResult<User>> DeleteUserAsync(int id)
        {
            // Find the Id.
            var domainUser = await _context.User.FindAsync(id);

            if (domainUser == null)
            {
                return domainUser;
            }

            _context.User.Remove(domainUser);
            await _context.SaveChangesAsync();

            return domainUser;
        }

        /// <summary>
        /// Check of an user exists.
        /// </summary>
        /// <param name="id">Id of the user.</param>
        /// <returns></returns>
        public bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}
