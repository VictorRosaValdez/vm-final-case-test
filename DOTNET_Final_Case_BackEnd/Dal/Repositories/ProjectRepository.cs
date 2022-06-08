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

        public Task<ActionResult<Project>> PostProjectAsync(Project domainProject)
        {
            throw new NotImplementedException();
        }

        //public async Task<ActionResult<Project>> PutProjectAsync(int id)
        //{
        //    // Find domain object by id
        //    var domainProject = await _context.Project.FindAsync(id);

        //    // Check if the domainProject is null.
        //    if (domainProject == null)
        //    {
        //        return null;
        //    }

        //    //// Update fields.
        //    //domainProject.Title = projectDto.Title;
        //    //domainProject.Description = projectDto.Description;
        //    //domainProject.Theme = projectDto.Theme;
        //    //domainProject.Industry = projectDto.Industry;
        //    //domainProject.Link = projectDto.Link;
        //    //domainProject.Screen = projectDto.Screen;
        //    //domainProject.Photo = projectDto.Photo;
        //    //domainProject.Progress = projectDto.Progress;

        //    return domainProject;
        //}

        public Task<ActionResult<Project>> DeleteProjectAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
