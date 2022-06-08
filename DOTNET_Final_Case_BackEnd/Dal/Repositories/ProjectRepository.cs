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

        public async Task<ActionResult<Project>> GetProjectAsync(int id)
        {
            // Assign it to the domain object.
            var domainProject = await _context.Project.FindAsync(id);

            return domainProject;
        }

        /// <summary>
        /// Adds a new project domain object to the database.
        /// </summary>
        /// <param name="domainProject">Project object.</param>
        public async Task PostProjectAsync(Project domainProject)
        {
            _context.Project.Add(domainProject);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a project from the database.
        /// </summary>
        /// <param name="id">Id of the project object.</param>
        /// <returns>The deleted object.</returns>
        public async Task<ActionResult<Project>> DeleteProjectAsync(int id)
        {
            // Find project by id
            var domainProject = await _context.Project.FindAsync(id);

            if (domainProject == null)
            {
                return domainProject;
            }

            _context.Project.Remove(domainProject);
            await _context.SaveChangesAsync();

            return domainProject;
        }
    }
}
