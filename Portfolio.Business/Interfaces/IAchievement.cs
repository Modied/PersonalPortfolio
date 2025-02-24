using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Interfaces
{
    public interface IAchievement
    {
        Task<AchievementVModel> GetAchievementAsync(int id);

        Task<IEnumerable<AchievementVModel>> GetAllAchievementsAsync(string[] includes);

        Task<int> AddAchievementAsync(AchievementVModel achievementVModel);
        Task<AchievementVModel> InitializeAchievementCreationAsync();
        Task UpdateAchievementAsync(AchievementVModel achievementVModel);
        Task<OprationStatusModel> DeleteAchievementAsync(int id);

    }
}
