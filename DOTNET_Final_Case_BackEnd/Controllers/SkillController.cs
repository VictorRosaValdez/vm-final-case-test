using AutoMapper;
using DOTNET_Final_Case_BackEnd.Dal.Repositories;
using DOTNET_Final_Case_BackEnd.DTOs.SkillDTO;
using DOTNET_Final_Case_BackEnd.Interfaces;
using DOTNET_Final_Case_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace DOTNET_Final_Case_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class SkillController : ControllerBase
    {
        // Private field
        private readonly ISkillRepository _skill;

        // Variable mapper for mapping the DTOs.
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor of the skill.
        /// </summary>
        /// <param name="skill"></param>
        public SkillController(ISkillRepository skill, IMapper mapper)
        {

            _skill = skill;
            _mapper = mapper;
        }

        // GET: api/skills
        /// <summary>
        /// Get all skills.
        /// </summary>
        /// <response code="200">Succesfully returns a list of skill objects.</response>
        /// <returns>A list of skill objects.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillReadDTO>>> GetSkills()
        {
            // Instance of the domainSkills objects.
            var domainSkills = await _skill.GetSkillsAsync();

            // Map domainSkills with SkillReadDTO
            var dtoSkill = _mapper.Map<List<SkillReadDTO>>(domainSkills.Value);

            return dtoSkill;
        }

        /// <summary>
        /// Get a skill by ID.
        /// </summary>
        /// <param name="id">Id of the skill.</param>
        /// <returns>A skillDto object.</returns>
        /// <response code="200">Succesfully returns a skill object.</response>
        /// <response code="400">Error: Response with this is a bad request.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillReadDTO>> GetSkill(int id)
        {
            // Instance of the domainSkill objects.
            var domainSkill = await _skill.GetSkillAsync(id);

            // Map domainProject with SkillReadDTO
            var dtoSkill = _mapper.Map<SkillReadDTO>(domainSkill.Value);

            if (dtoSkill == null)
            {
                return NotFound();
            }
            return dtoSkill;
        }

        // PUT: api/Skills/5
        /// <summary>
        /// Update a skill.
        /// </summary>
        /// <param name="id">Id of the skill</param>
        /// <param name="skillDto">SkillDto</param>
        /// <returns></returns>
        /// <response code="204">Succesfully object updated.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult<SkillUpdateDTO>> PutSkill(int id, SkillUpdateDTO skillDto)
        {
            // Intance of the SkillRepository
            SkillRepository skillRepository = new();

            // Instance of the domainSkill objects.
            var domainSkill = await _skill.PutSkillAsync(id, skillDto);

            // Map domainProject with SkillReadDTO
            var dtoSkill = _mapper.Map<SkillUpdateDTO>(domainSkill.Value);

            try
            {
                await _skill.PutSkillAsync(id, skillDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!skillRepository.SkillExists(dtoSkill.SkillId))
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


        // POST: api/Skill
        /// <summary>
        /// Create a skill object.
        /// </summary>
        /// <param name="skillDto"></param>
        /// <returns>The created SkillDto object.</returns>
        /// <response code="201">Succesfully object created.</response>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<SkillReadDTO>> PostSkill(SkillCreateDTO skillDto)
        {
            // Map domainSkill with SkillCreateDTO
            var domainSkill = _mapper.Map<Skill>(skillDto);

            // New Skill object.
            await _skill.PostSkillAsync(domainSkill);

            // Get Movie Id for new movie object.
            int skillId = _skill.PostSkillAsync(domainSkill).Id;

            // Returning the new Skill.
            return CreatedAtAction("GetSkill", new { id = skillId }, skillDto);
        }

        /// <summary>
        /// Delete a skill by Id.
        /// </summary>
        /// <param name="id">Id of the skillDto object.</param>
        /// <returns></returns>
        /// <response code="204">Succesfully object deleted.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<ActionResult<SkillDeleteDTO>> DeleteSkillAsync(int id)
        {
            // Instance of the domainSkill objects.
            var domainSkill = await _skill.DeleteSkillAsync(id);

            // Map SkillDeleteDTO with domainSkill.
            var dtoSkill = _mapper.Map<SkillDeleteDTO>(domainSkill.Value);

            if (dtoSkill == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
