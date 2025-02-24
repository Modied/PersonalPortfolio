using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Interfaces
{
    public interface ICompany
    {
        Task<CompanyVModel> GetCompanyAsync(int Id);
        Task<IEnumerable<CompanyVModel>> GetAllCompaniesAsync();
        Task AddCompanyAsync(CompanyVModel companyVModel);
        Task UpdateCompanyAsync(CompanyVModel companyVModel);
        Task<OprationStatusModel> DeleteCompanyAsync(int Id);
    }
}
