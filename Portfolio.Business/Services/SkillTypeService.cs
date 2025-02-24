using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Services
{
    public class SkillTypeService : ISkillType
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SkillTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task AddSkillTypeAsync(SkillTypeVModel skillTypeVModel)
        {
            var skillType = _mapper.Map<SkillType>(skillTypeVModel);
            return _unitOfWork.SkillTypeRepository.AddAsync(skillType);

        }

        public async Task<OprationStatusModel> DeleteSkillTypeAsync(int Id)
        {
            var operationStatus = new OprationStatusModel();
            var skillType = await _unitOfWork.SkillTypeRepository.GetByIDAsync(Id);
            if (skillType is not null)
            {
                await _unitOfWork.SkillTypeRepository.DeleteAsync(skillType);
                operationStatus.Status = true;
                return operationStatus;
            }
            operationStatus.Message = "SkillType not found";
            return operationStatus;
        }

        public async Task<IEnumerable<SkillTypeVModel>> GetAllSkillTypesAsync()
        {
            var skillTypes = await _unitOfWork.SkillTypeRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<SkillTypeVModel>>(skillTypes);
            return result;
        }

        public async Task<SkillTypeVModel> GetSkillTypeAsync(int Id)
        {
            var skillType = await _unitOfWork.SkillTypeRepository.GetByIDAsync(Id);
            var result = _mapper.Map<SkillTypeVModel>(skillType);
            return result;
        }

        public Task UpdateSkillTypeAsync(SkillTypeVModel skillTypeVModel)
        {
            var skillType = _mapper.Map<SkillType>(skillTypeVModel);
            return _unitOfWork.SkillTypeRepository.UpdateAsync(skillType, e => e.Id == skillTypeVModel.Id);

        }
    }
}
