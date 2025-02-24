using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.AutoMappers
{
    public class AchievementMapper : Profile
    {
        public AchievementMapper()
        {
            CreateMap<Achievement, AchievementVModel>().ReverseMap();
        }
    }
}
