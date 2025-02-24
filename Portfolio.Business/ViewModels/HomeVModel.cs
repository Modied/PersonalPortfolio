using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.ViewModels
{
    public class HomeVModel
    {
        public PersonalInfoVModel? PersonalInfo { get; set; }

        public List<AchievementVModel>? Achievements { get; set; } = new List<AchievementVModel>();

        public List<CompanyVModel>? Companies { get; set; } = new List<CompanyVModel>();

        public List<CustomerVModel>? Customers { get; set; } = new List<CustomerVModel>();

        public List<EducationVModel>? educationVModels { get; set; } = new List<EducationVModel>();

        public List<SkillVModel>? skillVModels { get; set; } = new List<SkillVModel>();

        public List<ToolVModel>? toolVModels { get; set; } = new List<ToolVModel>();

        public List<SocialVModel>? socialVModels { get; set; } = new List<SocialVModel>();

        public List<ServiceVModel>? serviceVModels { get; set; } = new List<ServiceVModel>();

        public MailVModel MailVModel { get; set; } = new MailVModel();





    }
}
