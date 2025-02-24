using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Interfaces
{
    public interface IEducationType
    {
        Task<EducationTypeVModel> GetEducationTypeAsync(int Id);
        Task<IEnumerable<EducationTypeVModel>> GetAllEducationTypesAsync();
        Task AddEducationTypeAsync(EducationTypeVModel educationTypeVModel);
        Task UpdateEducationTypeAsync(EducationTypeVModel educationTypeVModel);
        Task<OprationStatusModel> DeleteEducationTypeAsync(int Id);

    }
}
