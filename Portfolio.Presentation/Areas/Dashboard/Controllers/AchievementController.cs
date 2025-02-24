using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Domain.Models;


namespace Portfolio.Presentation.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class AchievementController : Controller
    {
        private readonly IAchievement _achievement;
        public AchievementController(IAchievement achievement)
        {
            _achievement = achievement;

        }
        public async Task<IActionResult> Index()
        {
            var result = await _achievement.GetAllAchievementsAsync(["Company", "Customer"]);
            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _achievement.GetAchievementAsync(id);
            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var result = await _achievement.InitializeAchievementCreationAsync();
            return View(result);

        }

        [HttpPost]
        public async Task<IActionResult> Create(AchievementVModel achievementVModel)
        {

            if (achievementVModel.CompanyId == -1 && achievementVModel.CustomerId == -1)
            {
                ModelState.AddModelError("", "You must select a company Or Custromer");
                var result = await _achievement.InitializeAchievementCreationAsync();
                return View(result);
            }


            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "You must fill all required filed ");
                return View(achievementVModel);
            }
            else
            {
                try
                {
                    await _achievement.AddAchievementAsync(achievementVModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(achievementVModel);
                }
            }

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _achievement.GetAchievementAsync(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AchievementVModel achievementVModel)
        {

            if (achievementVModel.CompanyId == -1 && achievementVModel.CustomerId == -1)
            {
                ModelState.AddModelError("", "You must select a company Or Custromer");
                var result = await _achievement.GetAchievementAsync(achievementVModel.Id);
                return View(result);
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "You must fill all required filed");
                return View(achievementVModel);
            }
            else
            {
                try
                {
                    await _achievement.UpdateAchievementAsync(achievementVModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _achievement.DeleteAchievementAsync(id);
            if (!result.Status)
            {
                ModelState.AddModelError("", result.Message.ToString());
                return View();
            }

            return RedirectToAction(nameof(Index));

        }
    }
}
