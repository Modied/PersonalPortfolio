using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<PersonalInfo> PersonalInfoRepository { get; }
        IBaseRepository<Skill> SkillRepository { get; }
        IBaseRepository<SocialMedia> SocialMediaRepository { get; }
        IBaseRepository<Tool> ToolRepository { get; }
        IBaseRepository<Education> EducationRepository { get; }
        IBaseRepository<Company> CompanyRepository { get; }
        IBaseRepository<Customer> CustomerRepository { get; }
        IBaseRepository<Achievement> AchievementRepository { get; }
        IBaseRepository<AchievedFor> AchievedForRepository { get; }

        IBaseRepository<EducationType> EducationTypeRepository { get; }
        IBaseRepository<SkillType> SkillTypeRepository { get; }

        IBaseRepository<Service> ServiceRepository { get; }


        int complet();
    }
}
