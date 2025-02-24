using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Services
{
    public class AchievedForService : IAchievedFor
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AchievedForService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> AddAchievedForAsync(AchievementVModel achievementVModel, int achievmentID)
        {
            var data = _mapper.Map<AchievedFor>(achievementVModel);
            data.AchievementId = achievmentID;
            await _unitOfWork.AchievedForRepository.AddAsync(data);
            return data.Id;
        }

        public Task<AchievementVModel> CreateAchievedForAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OprationStatusModel> DeleteAchievedForAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AchievementVModel> GetAchievedForAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AchievementVModel>> GetAllAchievedForAsync(string[] includes)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAchievedForAsync(AchievementVModel achievementVModel)
        {
            throw new NotImplementedException();
        }
    }
}
