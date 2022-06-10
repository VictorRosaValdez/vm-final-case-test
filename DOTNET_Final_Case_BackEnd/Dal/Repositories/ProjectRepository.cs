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
        /// Default constructor.
        /// </summary>
        public ProjectRepository()
        {
        }

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

        /// <summary>
        /// Get a project by id.
        /// </summary>
        /// <param name="id">An integer representing the id of the project.</param>
        /// <returns>A project domain object.</returns>
        public async Task<ActionResult<Project>> GetProjectAsync(int id)
        {
            // Assign it to the domain object.
            var domainProject = await _context.Project.FindAsync(id);

            return domainProject;
        }

        /// <summary>
        /// Update a project in the database.
        /// </summary>
        /// <param name="id">The id of the project.</param>
        /// <param name="project">The new project object.</param>
        /// <returns>The updated project object.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ActionResult<Project>> PutProjectAsync(int id, ProjectUpdateDTO projectDto)
        {
            // Find by Id.
            var domainProject = _context.Project.Find(id);

            // Check if the domainUser is null.
            if (domainProject == null)
            {
                return null;
            }

            // Update fields
            domainProject.Title = projectDto.Title;
            domainProject.Description = projectDto.Description;
            domainProject.Theme = projectDto.Theme;
            domainProject.Industry = projectDto.Industry;
            domainProject.Link = projectDto.Link;
            domainProject.Photo = projectDto.Photo;
            domainProject.Progress = projectDto.Progress;

            // Saving the update
            await _context.SaveChangesAsync();

            return domainProject;
        }

        /// <summary>
        /// Adds a new project domain object to the database.
        /// </summary>
        /// <param name="domainProject">Project object.</param>
        /// <returns>The new project object.</returns>
        public async Task<ActionResult<Project>> PostProjectAsync(Project project)
        {
            _context.Project.Add(project);
            await _context.SaveChangesAsync();

            return project;
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
                return null;
            }

            _context.Project.Remove(domainProject);
            await _context.SaveChangesAsync();

            return domainProject;
        }
        
    }
}
