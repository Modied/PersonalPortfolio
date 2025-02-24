using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Interfaces
{
    public interface ISocialMedia
    {
        Task<SocialVModel> GetSocialMediaAsync(int Id);
        Task<IEnumerable<SocialVModel>> GetAllSocialMediasAsync();
        Task AddSocialMediaAsync(SocialVModel socialVModel);
        Task UpdateSocialMediaAsync(SocialVModel socialVModel);
        Task<OprationStatusModel> DeleteSocialMediaAsync(int Id);
    }
}
