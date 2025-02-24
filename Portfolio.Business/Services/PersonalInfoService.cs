using AutoMapper;
using Microsoft.AspNetCore.Http;
using Portfolio.Business.Interfaces;
using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;


namespace Portfolio.Business.Services
{
    public class PersonalInfoService : IPersonalInfo
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileManager _fileManager;
        private readonly IWebHostEnvironment _hosting;
        private readonly IMapper _mapper;
        public PersonalInfoService(IUnitOfWork unitOfWork, IFileManager fileManager, IWebHostEnvironment hosting, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _fileManager = fileManager;
            _hosting = hosting;
            _mapper = mapper;
        }

        public async Task<PersonalInfo> AddPersonalInfoAsync(PersonalInfoVModel personalInfoVModel)
        {
            string fileName = await _fileManager.CopyFileName(personalInfoVModel.file) ?? string.Empty;
            personalInfoVModel.ImageUrl = fileName;
            var data = _mapper.Map<PersonalInfo>(personalInfoVModel);
            var result = await _unitOfWork.PersonalInfoRepository.AddAsync(data);

            return result;

        }

        public async Task<IEnumerable<PersonalInfoVModel>> GetPersonalInfoAsync()
        {
            var data = await _unitOfWork.PersonalInfoRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<PersonalInfoVModel>>(data);
            return result;

        }

        public async Task<PersonalInfoVModel> GetPersonalInfoByIDAsync(int id)
        {
            var data = await _unitOfWork.PersonalInfoRepository.GetByIDAsync(id);
            var result = _mapper.Map<PersonalInfoVModel>(data);
            return result;
        }

        public async Task<PersonalInfoVModel> GetFirstPersonalInfoAsync()
        {
            var data = await _unitOfWork.PersonalInfoRepository.GetFirstAsync();
            var result = _mapper.Map<PersonalInfoVModel>(data);
            return result;
        }

        public async Task<PersonalInfoVModel> GetFirstPersonalInfoAsync(int id)
        {
            var data = await _unitOfWork.PersonalInfoRepository.GetByIDAsync(id);
            var result = _mapper.Map<PersonalInfoVModel>(data);
            return result;
        }

        public async Task<PersonalInfo> UpdatePersonalInfoAsync(PersonalInfoVModel personalInfoVModel)
        {
            // CopyFileName(personalInfoVModel.file, personalInfoVModel.ImageUrl)
            string fileName = await _fileManager.CopyFileName(personalInfoVModel.file, personalInfoVModel.ImageUrl) ?? string.Empty;
            personalInfoVModel.ImageUrl = fileName;
            var data = _mapper.Map<PersonalInfo>(personalInfoVModel);
            return await _unitOfWork.PersonalInfoRepository.UpdateAsync(data, b => b.Id == personalInfoVModel.Id);
        }

        public async Task<OprationStatusModel> DeletePersonalInfoAsync(int id)
        {
            var oprationStatusModel = new OprationStatusModel();
            var result = await _unitOfWork.PersonalInfoRepository.GetByIDAsync(id);
            if (result != null)
            {
                _fileManager.DeletFileName(result.ImageUrl);
                await _unitOfWork.PersonalInfoRepository.DeleteAsync(result);
                oprationStatusModel.Status = true;
                return oprationStatusModel;
            }
            oprationStatusModel.Message = "Personal Info not found";

            return oprationStatusModel;
        }







    }
}
