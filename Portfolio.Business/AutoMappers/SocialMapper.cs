using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.AutoMappers
{
    public class SocialMapper : Profile
    {
        public SocialMapper()
        {
            CreateMap<SocialMedia, SocialVModel>().ReverseMap();
        }
    }
}
