using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Presentation.Areas.VisitorUI.Controllers
{
    [Area("VisitorUI")]
    public class HomeController : Controller
    {
        private readonly IAchievement _achievement;
        private readonly ICompany _company;
        private readonly ICustomer _customer;
        private readonly IEducation _education;
        private readonly IPersonalInfo _personalInfo;
        private readonly ISkill _skill;
        private readonly ITool _tool;
        private readonly ISocialMedia _social;
        private readonly IService _service;
        public HomeController(IAchievement achievement, ICompany company, ICustomer customer, IEducation education, IPersonalInfo personalInfo, ISkill skill, ITool tool, ISocialMedia social, IService service)
        {
            _achievement = achievement;
            _company = company;
            _customer = customer;
            _education = education;
            _personalInfo = personalInfo;
            _skill = skill;
            _tool = tool;
            _social = social;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var homeVModel = new HomeVModel
            {
                PersonalInfo = await _personalInfo.GetFirstPersonalInfoAsync(),
                Achievements = (await _achievement.GetAllAchievementsAsync(["Company", "Customer"])).ToList(),
                Companies = (await _company.GetAllCompaniesAsync()).ToList(),
                Customers = (await _customer.GetAllCustomersAsync()).ToList(),
                educationVModels = (await _education.GetAllEducationsAsync(["EducationTypes"])).ToList(),
                skillVModels = (await _skill.GetAllSkillsAsync(["SkillType"])).ToList(),
                toolVModels = (await _tool.GetAllToolsAsync()).ToList(),
                socialVModels = (await _social.GetAllSocialMediasAsync()).ToList(),
                serviceVModels = (await _service.GetAllServicesAsync()).ToList(),


            };
            return View(homeVModel);
        }

        public async Task<IActionResult> CVBuilder()
        {
            return View();
        }
    }
}
