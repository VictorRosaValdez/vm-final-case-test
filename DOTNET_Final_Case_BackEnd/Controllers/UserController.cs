using AutoMapper;
using DOTNET_Final_Case_BackEnd.DTOs.UserDTO;
using DOTNET_Final_Case_BackEnd.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace DOTNET_Final_Case_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        /// <response code="200">Succesfully returns a user object.</response>
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

    }
}