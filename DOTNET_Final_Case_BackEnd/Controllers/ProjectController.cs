using AutoMapper;
using DOTNET_Final_Case_BackEnd.Dal.Repositories;
using DOTNET_Final_Case_BackEnd.DTOs.ProjectDTO;
using DOTNET_Final_Case_BackEnd.Interfaces;
using DOTNET_Final_Case_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace DOTNET_Final_Case_BackEnd.Controllers
{
    [ApiController]
    [Route("api/projects")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _project;
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

        // GET: api/projects/3
        /// <summary>
        /// Get a project by ID.
        /// </summary>
        /// <param name="id">Id of the project.</param>
        /// <returns>A projectDto object.</returns>
        /// <response code="200">Succesfully returns a project object.</response>
        /// <response code="400">Error: Response with this is a bad request.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectReadDTO>> GetProject(int id)
        {
            var domainProject = await _project.GetProjectAsync(id);

            // Map domainProject to ProjectReadDTO
            var dtoProject = _mapper.Map<ProjectReadDTO>(domainProject.Value);

            if (dtoProject == null)
            {
                return NotFound();
            }

            return dtoProject;
        }

        /// <summary>
        /// Update a project.
        /// </summary>
        /// <param name="id">Id of the project</param>
        /// <param name="projectDto">ProjectDto</param>
        /// <returns>Action result without content.</returns>
        /// <response code="204">Succesfully updated object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutProject(int id, ProjectUpdateDTO projectDto)
        {
            // Check if id equals id of the object
            //if (id != projectDto.ProjectId)
            //{
            //    return BadRequest();
            //}

            // Instance of the ProjectRepository
            ProjectRepository projectRepository = new();

            // Instance of the domainProject objects
            var domainProject = await _project.PutProjectAsync(id, projectDto);

            // Map domainProject to ProjectUpdateDTO
            var dtoProject = _mapper.Map<ProjectUpdateDTO>(domainProject.Value);

            try
            {
                await _project.PutProjectAsync(id, projectDto);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!projectRepository.ProjectExists(dtoProject.ProjectId))
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

        // POST: api/projects
        /// <summary>
        /// Creates a new project object.
        /// </summary>
        /// <param name="projectDto">A Project Create DTO object.</param>
        /// <returns>A Project Read DTO object.</returns>
        /// <response code="201">Succesfully created object.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<ProjectCreateDTO>> PostUser(ProjectCreateDTO projectDto)
        {
            // Map ProjectCreateDTO to domain object
            var domainProject = _mapper.Map<Project>(projectDto);

            // New project object
            await _project.PostProjectAsync(domainProject);

            // Get project id for new project object.
            int projectId = _project.PostProjectAsync(domainProject).Id;

            // Returning the new user.
            return CreatedAtAction("GetProject", new { id = projectId }, projectDto);
        }

        /// <summary>
        /// Delete a project by Id.
        /// </summary>
        /// <param name="id">Id of the projectDto object.</param>
        /// <returns></returns>
        /// <response code="204">Succesfully deleted the project.</response>
        /// <response code="404">Error: The project you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<ActionResult> DeleteProjectAsync(int id)
        {
            // Instance of the domainUser objects.
            var domainProject = await _project.DeleteProjectAsync(id);

            if (domainProject == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}