using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Interfaces
{
    public interface ISkill
    {
        Task<SkillVModel> GetSkillAsync(int Id);
        Task<IEnumerable<SkillVModel>> GetAllSkillsAsync(string[] includs);
        Task AddSkillAsync(SkillVModel skillVModel);
        Task UpdateSkillAsync(SkillVModel skillVModel);
        Task<OprationStatusModel> DeleteSkillAsync(int Id);
        Task<SkillVModel> CreateSkillAsync();
    }
}
