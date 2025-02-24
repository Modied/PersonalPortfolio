using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Services
{
    public class SkillService : ISkill
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SkillService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddSkillAsync(SkillVModel skillVModel)
        {
            var skill = _mapper.Map<Skill>(skillVModel);
            await _unitOfWork.SkillRepository.AddAsync(skill);
        }

        public async Task<SkillVModel> CreateSkillAsync()
        {
            var skillTypes = await _unitOfWork.SkillTypeRepository.GetAllAsync();
            var result = new SkillVModel
            {
                SkillTypes = skillTypes.ToList()
            };
            return result;
        }

        public async Task<OprationStatusModel> DeleteSkillAsync(int Id)
        {
            var operationStatus = new OprationStatusModel();
            var skill = await _unitOfWork.SkillRepository.GetByIDAsync(Id);
            if (skill is not null)
            {
                await _unitOfWork.SkillRepository.DeleteAsync(skill);
                operationStatus.Status = true;
                return operationStatus;
            }
            operationStatus.Message = "Skill not found";
            return operationStatus;
        }

        public async Task<IEnumerable<SkillVModel>> GetAllSkillsAsync(string[] includes)
        {
            var skills = await _unitOfWork.SkillRepository.GetAllIncludesAsync(includes);
            var result = _mapper.Map<IEnumerable<SkillVModel>>(skills);
            return result;
        }

        public async Task<SkillVModel> GetSkillAsync(int Id)
        {
            var skill = await _unitOfWork.SkillRepository.GetByIDAsync(Id);
            var result = _mapper.Map<SkillVModel>(skill);
            result.SkillTypes = (await _unitOfWork.SkillTypeRepository.GetAllAsync()).ToList();
            return result;
        }

        public async Task UpdateSkillAsync(SkillVModel skillVModel)
        {
            var skill = _mapper.Map<Skill>(skillVModel);
            await _unitOfWork.SkillRepository.UpdateAsync(skill, s => s.Id == skillVModel.Id);
        }


    }
}
