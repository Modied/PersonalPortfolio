
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.AutoMappers
{
    public class PersonalInfoMapper : Profile
    {
        public PersonalInfoMapper()
        {
            CreateMap<PersonalInfo, PersonalInfoVModel>().ReverseMap();
        }
    }
}
