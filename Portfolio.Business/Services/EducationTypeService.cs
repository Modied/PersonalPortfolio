using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Services
{
    public class EducationTypeService : IEducationType
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EducationTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task AddEducationTypeAsync(EducationTypeVModel educationTypeVModel)
        {
            var educationType = _mapper.Map<EducationType>(educationTypeVModel);
            return _unitOfWork.EducationTypeRepository.AddAsync(educationType);
        }

        public async Task<OprationStatusModel> DeleteEducationTypeAsync(int Id)
        {
            var operationStatus = new OprationStatusModel();
            var educationType = await _unitOfWork.EducationTypeRepository.GetByIDAsync(Id);
            if (educationType is not null)
            {
                await _unitOfWork.EducationTypeRepository.DeleteAsync(educationType);
                operationStatus.Status = true;
                return operationStatus;
            }
            operationStatus.Message = "Education Type not found";
            return operationStatus;
        }

        public async Task<IEnumerable<EducationTypeVModel>> GetAllEducationTypesAsync()
        {
            var educationTypes = await _unitOfWork.EducationTypeRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<EducationTypeVModel>>(educationTypes);
            return result;

        }

        public async Task<EducationTypeVModel> GetEducationTypeAsync(int Id)
        {
            var educationType = await _unitOfWork.EducationTypeRepository.GetByIDAsync(Id);
            var result = _mapper.Map<EducationTypeVModel>(educationType);
            return result;

        }

        public Task UpdateEducationTypeAsync(EducationTypeVModel educationTypeVModel)
        {

            var educationType = _mapper.Map<EducationType>(educationTypeVModel);
            return _unitOfWork.EducationTypeRepository.UpdateAsync(educationType, e => e.Id == educationTypeVModel.Id);
        }
    }
}
