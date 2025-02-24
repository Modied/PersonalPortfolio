using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.AutoMappers
{
    public class SkillMapper : Profile
    {
        public SkillMapper()
        {
            CreateMap<Skill, SkillVModel>().ForMember(dest => dest.SkillTypes,
                                                    opt => opt.Ignore());

            CreateMap<SkillVModel, Skill>().ForMember(dest => dest.SkillType, opt => opt.Ignore());
        }
    }
}
