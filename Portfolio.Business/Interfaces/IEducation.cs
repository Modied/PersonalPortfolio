using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Interfaces
{
    public interface IEducation
    {
        Task<EducationVModel> GetEducationAsync(int Id);
        Task<IEnumerable<EducationVModel>> GetAllEducationsAsync(string[] Includes);
        Task AddEducationAsync(EducationVModel educationVModel);
        Task <EducationVModel> CreateEducationAsync();
        Task UpdateEducationAsync(EducationVModel educationVModel);
        Task<OprationStatusModel> DeleteEducationAsync(int Id);
    }
}
