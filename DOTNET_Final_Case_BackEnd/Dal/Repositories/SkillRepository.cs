using DOTNET_Final_Case_BackEnd.DTOs.SkillDTO;
using DOTNET_Final_Case_BackEnd.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Final_Case_BackEnd.Dal.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        public Task<ActionResult<SkillDeleteDTO>> DeleteSkillAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<SkillReadDTO>> GetSkillAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<SkillReadDTO>>> GetSkillsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<SkillReadDTO>> PostSkillAsync(SkillCreateDTO skillDto)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<SkillUpdateDTO>> PutSkillAsync(int id, SkillUpdateDTO skillDto)
        {
            throw new NotImplementedException();
        }
    }
}
