using Portfolio.Business.Interfaces;
using Portfolio.Data.Context;
using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PortfolioDBContext _dbContext;
        public IBaseRepository<PersonalInfo> PersonalInfoRepository { get; private set; }
        public IBaseRepository<Skill> SkillRepository { get; private set; }
        public IBaseRepository<SocialMedia> SocialMediaRepository { get; private set; }
        public IBaseRepository<Tool> ToolRepository { get; private set; }
        public IBaseRepository<Education> EducationRepository { get; private set; }
        public IBaseRepository<Company> CompanyRepository { get; private set; }
        public IBaseRepository<Customer> CustomerRepository { get; private set; }
        public IBaseRepository<Achievement> AchievementRepository { get; private set; }

        public IBaseRepository<AchievedFor> AchievedForRepository { get; private set; }
        public IBaseRepository<EducationType> EducationTypeRepository { get; private set; }

        public IBaseRepository<SkillType> SkillTypeRepository { get; private set; }

        public IBaseRepository<Service> ServiceRepository { get; private set; }

        public UnitOfWork(PortfolioDBContext dbcontext)
        {
            _dbContext = dbcontext;
            PersonalInfoRepository = new BaseRepository<PersonalInfo>(_dbContext);
            SkillRepository = new BaseRepository<Skill>(_dbContext);
            SocialMediaRepository = new BaseRepository<SocialMedia>(_dbContext);
            ToolRepository = new BaseRepository<Tool>(_dbContext);
            AchievementRepository = new BaseRepository<Achievement>(_dbContext);
            AchievedForRepository = new BaseRepository<AchievedFor>(_dbContext);
            EducationRepository = new BaseRepository<Education>(_dbContext);
            CompanyRepository = new BaseRepository<Company>(_dbContext);
            CustomerRepository = new BaseRepository<Customer>(_dbContext);
            EducationTypeRepository = new BaseRepository<EducationType>(_dbContext);
            SkillTypeRepository = new BaseRepository<SkillType>(_dbContext);
            ServiceRepository = new BaseRepository<Service>(_dbContext);
        }

        public int complet()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
