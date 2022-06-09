using DOTNET_Final_Case_BackEnd.DTOs.ProjectDTO;
using DOTNET_Final_Case_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Final_Case_BackEnd.Interfaces
{
    public interface IProjectRepository
    {
        /// <summary>
        /// Abstract method to get all projects.
        /// </summary>
        /// <returns>A list of projects.</returns>
        Task<ActionResult<IEnumerable<Project>>> GetProjectsAsync();

        /// <summary>
        /// Abstract method to get a project by Id.
        /// </summary>
        /// <param name="id">The id of the project.</param>
        /// <returns>The project object.</returns>
        Task<ActionResult<Project>> GetProjectAsync(int id);

        /// <summary>
        /// Abstract method to update a project.
        /// </summary>
        /// <param name="id">The id of the project.</param>
        /// <param name="project">A Project Update DTO.</param>
        /// <returns>The project object.</returns>
        Task<ActionResult<Project>> PutProjectAsync(int id, ProjectUpdateDTO projectDto);

        /// <summary>
        /// Abstract method to add a new project.
        /// </summary>
        /// <param name="project">Project type</param>
        /// <returns>The new project object.</returns>
        Task<ActionResult<Project>> PostProjectAsync(Project project);

        /// <summary>
        /// Abstract method to delete a project.
        /// </summary>
        /// <param name="id">The id of the project</param>
        /// <returns></returns>
        Task<ActionResult<Project>> DeleteProjectAsync(int id);

    }
}
