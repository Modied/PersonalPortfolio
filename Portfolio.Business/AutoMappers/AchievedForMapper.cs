using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.AutoMappers
{
    public class AchievedForMapper : Profile
    {
        public AchievedForMapper()
        {
            CreateMap<AchievedFor, AchievementVModel>().ForMember(dest => dest.Id, src => src.Ignore())
                                                       .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                                                       .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId)).ReverseMap();

            //CreateMap<AchievementVModel, AchievedFor>().ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId));


        }
    }
}
