using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Portfolio.Presentation.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        private readonly ISkill _skill;

        public SkillController(ISkill skill)
        {
            _skill = skill;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _skill.GetAllSkillsAsync(["SkillType"]);
            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _skill.GetSkillAsync(id);
            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var result = await _skill.CreateSkillAsync();
            return View(result);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SkillVModel skillVModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "You must fill all required filed ");
                return View(skillVModel);
            }

            try
            {
                await _skill.AddSkillAsync(skillVModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Create");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _skill.GetSkillAsync(id);
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(SkillVModel skillVModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "You must fill all required filed ");
                return View(skillVModel);
            }
            else
            {
                try
                {
                    await _skill.UpdateSkillAsync(skillVModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(skillVModel);
                }
            }

        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _skill.DeleteSkillAsync(id);
            if (!result.Status)
            {
                ModelState.AddModelError("", result.Message);
                return View();
            }

            return RedirectToAction(nameof(Index));

        }
    }
}
