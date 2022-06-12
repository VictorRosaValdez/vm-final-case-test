using AutoMapper;
using DOTNET_Final_Case_BackEnd.Dal.Repositories;
using DOTNET_Final_Case_BackEnd.DTOs.UserDTO;
using DOTNET_Final_Case_BackEnd.Interfaces;
using DOTNET_Final_Case_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace DOTNET_Final_Case_BackEnd.Controllers
{
    [ApiController]
    [Route("/users")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class UserController : ControllerBase
    {
        // Private field
        private readonly IUserRepository _user;

        // Variable mapper for mapping the DTOs.
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor of the project.
        /// </summary>
        /// <param name="project"></param>
        public UserController(IUserRepository user, IMapper mapper)
        {

            _user = user;
            _mapper = mapper;
        }

        // GET: api/users
        /// <summary>
        /// Get all users.
        /// </summary>
        /// <response code="200">Succesfully returns a list of user object.</response>
        /// <returns>A list of user objects.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDTO>>> GetUsers()
        {
            // Instance of the domainUser objects.
            var domainUsers = await _user.GetUsersAsync();

            // Map domainProject with UserReadDTO
            var dtoUser = _mapper.Map<List<UserReadDTO>>(domainUsers.Value);

            return dtoUser;

        }

        /// <summary>
        /// Get an user by ID.
        /// </summary>
        /// <param name="id">Id of the user.</param>
        /// <returns>An userDto object.</returns>
        /// <response code="200">Succesfully returns an user object.</response>
        /// <response code="400">Error: Response with this is a bad request.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDTO>> GetUser( int id)
        {
            // Instance of the domainUser objects.
            var domainUser = await _user.GetUserAsync(id);

            // Map domainProject with UserReadDTO
            var dtoUser = _mapper.Map<UserReadDTO>(domainUser.Value);

            if (dtoUser == null)
            {
                return NotFound();
            }

            return dtoUser;

        }

        // PUT: api/Users/5
        /// <summary>
        /// Update an user.
        /// </summary>
        /// <param name="id">Id of the user</param>
        /// <param name="userDto">UserDto</param>
        /// <returns></returns>
        /// <response code="204">Succesfully object updated.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult<UserUpdateDTO>> PutUser(int id, UserUpdateDTO userDto)
        {
            // Check if id equals id of the object.
            if (id != userDto.UserId)
            {
                return BadRequest();
            }
            //
            // Instance of the domainUser objects.
            var domainUser = await _user.PutUserAsync(id, userDto);

            // Check if the value is null.
            if (domainUser == null)
            {
                return NotFound();
            }

            try
            {
                await _user.PutUserAsync(id, userDto);

            }
            catch (DbUpdateConcurrencyException)

            {
                    throw;
            }

            return NoContent();
        }

        // POST: api/User
        /// <summary>
        /// Create an user object.
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns>The created userDto object.</returns>
        /// <response code="201">Succesfully object created.</response>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<UserReadDTO>> PostUser(UserCreateDTO userDto)
        {
            // Map domainUser with UserCreateDTO
            var domainUser = _mapper.Map<User>(userDto);

            // New user object.
            await _user.PostUserAsync(domainUser);

            // Get User Id for new user object.
            int userId = _user.PostUserAsync(domainUser).Id;

            // Returning the new user.
            return CreatedAtAction("GetUser", new { id = userId }, userDto);
        }

        /// <summary>
        /// Delete an user by Id.
        /// </summary>
        /// <param name="id">Id of the userDto object.</param>
        /// <returns></returns>
        /// <response code="204">Succesfully object deleted.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<ActionResult<UserDeleteDTO>> DeleteUserAsync(int id)
        {
            // Instance of the domainUser objects.
            var domainUser = await _user.DeleteUserAsync(id);

            if (domainUser == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}