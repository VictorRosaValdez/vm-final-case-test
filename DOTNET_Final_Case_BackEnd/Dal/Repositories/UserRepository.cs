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
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<User>>> GetUsersAsync()
        {
                // Assign it to the domain object.
                var domainUsers = await _context.User.ToListAsync();

                return domainUsers;
            
        }

        public async Task<ActionResult<User>> GetUserAsync(int id)
        {
            // Assign it to the domain object.
            var domainUser = await _context.User.FindAsync(id);

            return domainUser;
        }

        public async Task<ActionResult<User>> PutUserAsync(int id, UserUpdateDTO userDto)
        {
            // Find the Id.
            var domainUser = _context.User.Find(id);

            domainUser.Name = userDto.Name;
            domainUser.Email = userDto.Email;
            domainUser.Portfolio = userDto.Portfolio;
            domainUser.Description = userDto.Description;

            // Saving the update
            await _context.SaveChangesAsync();

            return domainUser;
        }
        public async Task<ActionResult<User>> PostUserAsync(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return user;

        }

        public async Task<ActionResult<User>> DeleteUserAsync(int id)
        {
            // Find the Id.
            var domainUser = await _context.User.FindAsync(id);

            _context.User.Remove(domainUser);
            await _context.SaveChangesAsync();

            return domainUser;
        }

        public bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}
