using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Interfaces
{
    public interface IAchievedFor
    {
        Task<AchievementVModel> GetAchievedForAsync(int id);

        Task<IEnumerable<AchievementVModel>> GetAllAchievedForAsync(string[] includes);

        Task<int> AddAchievedForAsync(AchievementVModel achievementVModel, int achievmentID);
        Task<AchievementVModel> CreateAchievedForAsync();
        Task UpdateAchievedForAsync(AchievementVModel achievementVModel);
        Task<OprationStatusModel> DeleteAchievedForAsync(int id);



    }
}
