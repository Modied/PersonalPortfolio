using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Services
{
    public class CompanyService : ICompany
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileManager _fileManager;
        private readonly IWebHostEnvironment _hosting;
        private readonly IMapper _mapper;
        public CompanyService(IUnitOfWork unitOfWork, IFileManager fileManager, IWebHostEnvironment hosting, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _fileManager = fileManager;
            _hosting = hosting;
            _mapper = mapper;
        }
        public async Task AddCompanyAsync(CompanyVModel companyVModel)
        {
            await _unitOfWork.CompanyRepository.AddAsync(_mapper.Map<Company>(companyVModel));
        }

        public async Task<OprationStatusModel> DeleteCompanyAsync(int Id)
        {
            var operationStatus = new OprationStatusModel();
            var company = await _unitOfWork.CompanyRepository.GetByIDAsync(Id);
            if (company is not null)
            {
                await _unitOfWork.CompanyRepository.DeleteAsync(company);
                operationStatus.Status = true;
                return operationStatus;
            }
            operationStatus.Message = "Company not found";
            return operationStatus;
        }

        public async Task<IEnumerable<CompanyVModel>> GetAllCompaniesAsync()
        {
            var companies = await _unitOfWork.CompanyRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CompanyVModel>>(companies);
            return result;

        }

        public async Task<CompanyVModel> GetCompanyAsync(int Id)
        {
            var company = await _unitOfWork.CompanyRepository.GetByIDAsync(Id);
            var result = _mapper.Map<CompanyVModel>(company);
            return result;

        }

        public async Task UpdateCompanyAsync(CompanyVModel companyVModel)
        {
            var company = _mapper.Map<Company>(companyVModel);
            await _unitOfWork.CompanyRepository.UpdateAsync(company, c => c.Id == companyVModel.Id);
        }
    }
}
