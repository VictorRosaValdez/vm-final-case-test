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

        public UserRepository()
        {
        }

        /// <summary>
        /// Constructor for the ProjectRepository
        /// </summary>
        /// <param name="context">Db context</param>
        public UserRepository(ProjectsDbContext context)
        {
            _context = context;

        }

        public Task<ActionResult<User>> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<User>> GetUserAsync(int id)
        {
            throw new NotImplementedException();
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

        public Task<ActionResult<User>> PostUserAsync(User domainuser)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<User>> PutUserAsync(int id, User domainUser)
        {
            throw new NotImplementedException();
        }
    }
}
