using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Services
{
    public class ServiceService : IService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileManager _fileManager;
        private readonly IWebHostEnvironment _hosting;
        private readonly IMapper _mapper;
        public ServiceService(IUnitOfWork unitOfWork, IFileManager fileManager, IWebHostEnvironment hosting, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _fileManager = fileManager;
            _hosting = hosting;
            _mapper = mapper;
        }

        public async Task AddServiceAsync(ServiceVModel serviceVModel)
        {
            var fileName = await _fileManager.CopyFileName(serviceVModel.IconFile) ?? string.Empty;
            serviceVModel.iconPath = fileName;
            await _unitOfWork.ServiceRepository.AddAsync(_mapper.Map<Service>(serviceVModel));


        }

        public async Task<OprationStatusModel> DeleteServiceAsync(int id)
        {
            var operationStatus = new OprationStatusModel();
            var service = await _unitOfWork.ServiceRepository.GetByIDAsync(id);
            if (service is not null)
            {
                _fileManager.DeletFileName(service.iconPath);
                await _unitOfWork.ServiceRepository.DeleteAsync(service);
                operationStatus.Status = true;
                return operationStatus;
            }
            operationStatus.Message = "Service not found";
            return operationStatus;
        }

        public async Task<IEnumerable<ServiceVModel>> GetAllServicesAsync()
        {
            var services = await _unitOfWork.ServiceRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<ServiceVModel>>(services);
            return result;
        }

        public async Task<ServiceVModel> GetServiceByIdAsync(int id)
        {
            var service = await _unitOfWork.ServiceRepository.GetByIDAsync(id);
            var result = _mapper.Map<ServiceVModel>(service);
            return result;
        }

        public async Task UpdateServiceAsync(ServiceVModel serviceVModel)
        {
            if (serviceVModel.IconFile is not null)
            {
                var fileName = await _fileManager.CopyFileName(serviceVModel.IconFile) ?? string.Empty;
                serviceVModel.iconPath = fileName;
            }
            var service = _mapper.Map<Service>(serviceVModel);
            await _unitOfWork.ServiceRepository.UpdateAsync(service, S => S.Id == serviceVModel.Id);


        }
    }
}
