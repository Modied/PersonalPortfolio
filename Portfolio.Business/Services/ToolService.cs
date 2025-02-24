using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Services
{
    public class ToolService : ITool
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ToolService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddToolAsync(ToolVModel toolVModel)
        {
            var tool = _mapper.Map<Tool>(toolVModel);
            await _unitOfWork.ToolRepository.AddAsync(tool);
        }

        public async Task<OprationStatusModel> DeleteToolAsync(int Id)
        {
            var operationStatus = new OprationStatusModel();
            var tool = await _unitOfWork.ToolRepository.GetByIDAsync(Id);
            if (tool is not null)
            {
                await _unitOfWork.ToolRepository.DeleteAsync(tool);
                operationStatus.Status = true;
                return operationStatus;
            }
            operationStatus.Message = "Tool not found";
            return operationStatus;
        }

        public async Task<IEnumerable<ToolVModel>> GetAllToolsAsync()
        {
            var tools = await _unitOfWork.ToolRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<ToolVModel>>(tools);
            return result;
        }

        public async Task<ToolVModel> GetToolAsync(int Id)
        {
            var tool = await _unitOfWork.ToolRepository.GetByIDAsync(Id);
            var result = _mapper.Map<ToolVModel>(tool);
            return result;
        }

        public async Task UpdateToolAsync(ToolVModel toolVModel)
        {
            var tool = _mapper.Map<Tool>(toolVModel);
            await _unitOfWork.ToolRepository.UpdateAsync(tool, t => t.Id == toolVModel.Id);
        }
    }
}
