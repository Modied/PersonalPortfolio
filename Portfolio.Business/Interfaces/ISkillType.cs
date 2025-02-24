using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Interfaces
{
    public interface ISkillType
    {
        Task<SkillTypeVModel> GetSkillTypeAsync(int Id);
        Task<IEnumerable<SkillTypeVModel>> GetAllSkillTypesAsync();
        Task AddSkillTypeAsync(SkillTypeVModel skillTypeVModel);
        Task UpdateSkillTypeAsync(SkillTypeVModel skillTypeVModel);
        Task<OprationStatusModel> DeleteSkillTypeAsync(int Id);


    }
}
