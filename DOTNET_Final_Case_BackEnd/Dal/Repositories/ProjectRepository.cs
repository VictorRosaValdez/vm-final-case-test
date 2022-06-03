using DOTNET_Final_Case_BackEnd.DTOs.ProjectDTO;
using DOTNET_Final_Case_BackEnd.Interfaces;
using DOTNET_Final_Case_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DOTNET_Final_Case_BackEnd.Dal.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        // Fields

        // Variable for the DbContext.
        private readonly ProjectsDbContext _context;

        /// <summary>
        /// Constructor for the ProjectRepository
        /// </summary>
        /// <param name="context">Db context</param>
        public ProjectRepository(ProjectsDbContext context)
        {
            _context = context;

        }


        /// <summary>
        /// Get all projects.
        /// </summary>
        /// <returns>A list of projects.</returns>
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsAsync()
        {
            // Assign it to the domain object.
            var domainProjects = await _context.Project.ToListAsync();

            return domainProjects;
        }

        public Task<ActionResult<Project>> GetProjectAsync(int id)
        {
            throw new NotImplementedException();
        }

       

        public Task<ActionResult<Project>> PostProjectAsync(Project domainProject)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Project>> PutProjectAsync(int id, Project domainProject)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Project>> DeleteProjectAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
