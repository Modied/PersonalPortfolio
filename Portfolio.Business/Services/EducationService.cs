using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Services
{
    public class EducationService : IEducation
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EducationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddEducationAsync(EducationVModel educationVModel)
        {
            var education = _mapper.Map<Education>(educationVModel);
            await _unitOfWork.EducationRepository.AddAsync(education);
        }

        public async Task<EducationVModel> CreateEducationAsync()
        {
            var educationTypes = await _unitOfWork.EducationTypeRepository.GetAllAsync();
            var result = new EducationVModel
            {
                EducationTypes = educationTypes.ToList()
            };
            return result;
        }

        public async Task<OprationStatusModel> DeleteEducationAsync(int Id)
        {
            var operationStatus = new OprationStatusModel();
            var education = await _unitOfWork.EducationRepository.GetByIDAsync(Id);
            if (education is not null)
            {
                await _unitOfWork.EducationRepository.DeleteAsync(education);
                operationStatus.Status = true;
                return operationStatus;
            }
            operationStatus.Message = "Education not found";
            return operationStatus;
        }

        public async Task<IEnumerable<EducationVModel>> GetAllEducationsAsync(string[] Includes)
        {

            var educations = await _unitOfWork.EducationRepository.GetAllIncludesAsync(Includes);
            var result = _mapper.Map<IEnumerable<EducationVModel>>(educations);
            return result;
        }

        public async Task<EducationVModel> GetEducationAsync(int Id)
        {
            var education = await _unitOfWork.EducationRepository.GetByIDAsync(Id);
            var result = _mapper.Map<EducationVModel>(education);
            result.EducationTypes = (await _unitOfWork.EducationTypeRepository.GetAllAsync()).ToList();
            return result;
        }

        public Task UpdateEducationAsync(EducationVModel educationVModel)
        {
            var education = _mapper.Map<Education>(educationVModel);
            return _unitOfWork.EducationRepository.UpdateAsync(education, e => e.Id == educationVModel.Id);

        }
    }
}
