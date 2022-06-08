using DOTNET_Final_Case_BackEnd.DTOs.SkillDTO;
using DOTNET_Final_Case_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Final_Case_BackEnd.Interfaces
{
    public interface ISkillRepository
    {
        /// <summary>
        /// Abstract method to get all skills.
        /// </summary>
        /// <returns>A list of skillDto.</returns>
        Task<ActionResult<IEnumerable<Skill>>> GetSkillsAsync();

        /// <summary>
        /// Abstract method for get a skill by Id.
        /// </summary>
        /// <param name="id">The id of the skill.</param>
        /// <returns>The skillDto object.</returns>
        Task<ActionResult<Skill>> GetSkillAsync(int id);

        /// <summary>
        /// Abstract method to create a skill.
        /// </summary>
        /// <param name="skillDto">SkillDto object.</param>
        /// <returns>The new skillDto object</returns>
        Task<ActionResult<Skill>> PostSkillAsync(Skill skill);

        /// <summary>
        /// Abstract method to update a skill.
        /// </summary>
        /// <param name="id">The id of the skill</param>
        /// <param name="skillDto">SkillDto object</param>
        /// <returns>SkillDto object.</returns>
        Task<ActionResult<Skill>> PutSkillAsync(int id, SkillUpdateDTO skillDto);

        /// <summary>
        /// Abstract method to delete a skill.
        /// </summary>
        /// <param name="id">The id of the skill</param>
        /// <returns></returns>
        Task<ActionResult<Skill>> DeleteSkillAsync(int id);
    }
}
