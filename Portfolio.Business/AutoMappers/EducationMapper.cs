using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.AutoMappers
{
    public class EducationMapper : Profile
    {
        public EducationMapper()
        {

            CreateMap<Education, EducationVModel>().ForMember(dest => dest.EducationTypes,
                                                                opt => opt.Ignore());
            CreateMap<EducationVModel, Education>().ForMember(dest => dest.EducationTypes, opt => opt.Ignore());

        }

    }
}
