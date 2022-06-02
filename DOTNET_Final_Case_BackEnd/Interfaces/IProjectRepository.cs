using DOTNET_Final_Case_BackEnd.DTOs.ProjectDTO;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Final_Case_BackEnd.Interfaces
{
    public interface IProjectRepository
    {
        /// <summary>
        /// Abstract method for get all projects.
        /// </summary>
        /// <returns>A list of projectDto.</returns>
        Task<ActionResult<IEnumerable<ProjectReadDTO>>> GetProjectsAsync();

        /// <summary>
        /// Abstract method for get a project by Id.
        /// </summary>
        /// <param name="id">The id of the project.</param>
        /// <returns>The projectDto object.</returns>
        Task<ActionResult<ProjectReadDTO>> GetProjectAsync(int id);



        /// <summary>
        /// Abstract method for create a project.
        /// </summary>
        /// <param name="projectDto">projectDto object.</param>
        /// <returns>The new projectDto object</returns>
        Task<ActionResult<ProjectReadDTO>> PostProjectAsync(ProjectCreateDTO projectDto);

        /// <summary>
        /// Abstract method to update a project.
        /// </summary>
        /// <param name="id">The id of the project</param>
        /// <param name="projectDto">ProjectDto object</param>
        /// <returns>ProjectDto object.</returns>
        Task<ActionResult<ProjectUpdateDTO>> PutProjectAsync(int id, ProjectUpdateDTO projectDto);

        /// <summary>
        /// Abstract method to delete a project.
        /// </summary>
        /// <param name="id">The id of the project</param>
        /// <returns></returns>
        Task<ActionResult<ProjectDeleteDTO>> DeleteProjectAsync(int id);
    }
}
