using AutoMapper;
using DOTNET_Final_Case_BackEnd.DTOs.ProjectDTO;
using DOTNET_Final_Case_BackEnd.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace DOTNET_Final_Case_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ProjectController : ControllerBase
    {
        // Private field
        private readonly IProjectRepository _project;

        // Variable mapper for mapping the DTOs.
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor of the project.
        /// </summary>
        /// <param name="project"></param>
        public ProjectController(IProjectRepository project, IMapper mapper)
        {

            _project = project;
            _mapper = mapper;
        }

        // GET: api/projects
        /// <summary>
        /// Get all projects.
        /// </summary>
        /// <response code="200">Succesfully returns a project object.</response>
        /// <returns>A list of ProjectDto objects.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectReadDTO>>> GetProjects()
        {
            // Instance of the domainProject objects.
            var domainProjects = await _project.GetProjectsAsync();


            // Map domainProject with ProjectReadDTO
            var dtoProject = _mapper.Map<List<ProjectReadDTO>>(domainProjects.Value);

            return dtoProject;

        }

    }
}