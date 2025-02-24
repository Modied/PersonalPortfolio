using Microsoft.AspNetCore.Hosting;
using Portfolio.Business.Interfaces;
using Portfolio.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Services
{
    public class SocialService : ISocialMedia
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;
        public SocialService(IUnitOfWork unitOfWork, IMapper mapper, IFileManager fileManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileManager = fileManager;
        }
        public async Task AddSocialMediaAsync(SocialVModel socialVModel)
        {
            string fileName = await _fileManager.CopyFileName(socialVModel.IconFile) ?? string.Empty;
            socialVModel.Icon = fileName;
            var social = _mapper.Map<SocialMedia>(socialVModel);
            await _unitOfWork.SocialMediaRepository.AddAsync(social);
        }

        public async Task<OprationStatusModel> DeleteSocialMediaAsync(int Id)
        {
            var operationStatus = new OprationStatusModel();
            var social = await _unitOfWork.SocialMediaRepository.GetByIDAsync(Id);
            if (social is not null)
            {
                _fileManager.DeletFileName(social.Icon);
                await _unitOfWork.SocialMediaRepository.DeleteAsync(social);
                operationStatus.Status = true;
                return operationStatus;
            }
            operationStatus.Message = "Social Media not found";
            return operationStatus;
        }

        public async Task<IEnumerable<SocialVModel>> GetAllSocialMediasAsync()
        {
            var socials = await _unitOfWork.SocialMediaRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<SocialVModel>>(socials);
            return result;
        }

        public async Task<SocialVModel> GetSocialMediaAsync(int Id)
        {
            var social = await _unitOfWork.SocialMediaRepository.GetByIDAsync(Id);
            var result = _mapper.Map<SocialVModel>(social);
            return result;
        }

        public async Task UpdateSocialMediaAsync(SocialVModel socialVModel)
        {
            if (socialVModel.IconFile is not null)
            {
                string fileName = await _fileManager.CopyFileName(socialVModel.IconFile, socialVModel.Icon) ?? string.Empty;
                socialVModel.Icon = fileName;
            }
            var social = _mapper.Map<SocialMedia>(socialVModel);
            await _unitOfWork.SocialMediaRepository.UpdateAsync(social, s => s.Id == socialVModel.Id);

        }
    }
}
