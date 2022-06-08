using DOTNET_Final_Case_BackEnd.DTOs.SkillDTO;
using DOTNET_Final_Case_BackEnd.Interfaces;
using DOTNET_Final_Case_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DOTNET_Final_Case_BackEnd.Dal.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        // Fields

        // Variable for the DbContext.
        private readonly ProjectsDbContext _context;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SkillRepository()
        {
        }

        /// <summary>
        /// Constructor for the ProjectRepository.
        /// </summary>
        /// <param name="context">Db context</param>
        public SkillRepository(ProjectsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all skills.
        /// </summary>
        /// <returns>A list of skill objects.</returns>
        public async Task<ActionResult<IEnumerable<Skill>>> GetSkillsAsync()
        {
            // Assign it to the domain object.
            var domainSkills = await _context.Skill.ToListAsync();

            return domainSkills;
        }

        /// <summary>
        /// Get a skill by ID.
        /// </summary>
        /// <param name="id">Id of the skill</param>
        /// <returns>An skill object.</returns>
        public async Task<ActionResult<Skill>> GetSkillAsync(int id)
        {
            // Assign it to the domain object.
            var domainSkill = await _context.Skill.FindAsync(id);

            return domainSkill;
        }

        /// <summary>
        /// Update an skill object.
        /// </summary>
        /// <param name="id">Id of the skill.</param>
        /// <param name="skillDto">skillUpdateDTO object.</param>
        /// <returns>An skill object.</returns>
        public async Task<ActionResult<Skill>> PutSkillAsync(int id, SkillUpdateDTO skillDto)
        {
            // Find the Id.
            var domainSkill = _context.Skill.Find(id);

            // Check if the domainSkill is null.
            if (domainSkill == null)
            {
                return domainSkill;
            }

            // Update fields.
            domainSkill.Name = skillDto.Name;

            // Saving the update
            await _context.SaveChangesAsync();

            return domainSkill;
        }

        /// <summary>
        /// Create a new skill object.
        /// </summary>
        /// <param name="skill">Skill object.</param>
        /// <returns>The new skill object.</returns>
        public async Task<ActionResult<Skill>> PostSkillAsync(Skill skill)
        {
            _context.Skill.Add(skill);
            await _context.SaveChangesAsync();

            return skill;
        }

        /// <summary>
        /// Delete an skill object.
        /// </summary>
        /// <param name="id">Id of the skill object.</param>
        /// <returns>The deleted object.</returns>
        public async Task<ActionResult<Skill>> DeleteSkillAsync(int id)
        {
            // Find the Id.
            var domainSkill = await _context.Skill.FindAsync(id);

            if (domainSkill == null)
            {
                return domainSkill;
            }

            _context.Skill.Remove(domainSkill);
            await _context.SaveChangesAsync();

            return domainSkill;
        }

        /// <summary>
        /// Check of an skill exists.
        /// </summary>
        /// <param name="id">Id of the skill.</param>
        /// <returns></returns>
        public bool SkillExists(int id)
        {
            return _context.Skill.Any(e => e.SkillId == id);
        }
    }
}
