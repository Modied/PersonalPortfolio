using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Presentation.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles ="Admin")]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMedia _socialMedia;
        public SocialMediaController(ISocialMedia socialMedia)
        {
            _socialMedia = socialMedia;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _socialMedia.GetAllSocialMediasAsync();
            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _socialMedia.GetSocialMediaAsync(id);

            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new SocialVModel { });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SocialVModel socialVModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "You must fill all required filed ");
                return View(socialVModel);
            }
            else
            {
                try
                {
                    await _socialMedia.AddSocialMediaAsync(socialVModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(socialVModel);
                }
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _socialMedia.GetSocialMediaAsync(id);
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(SocialVModel socialVModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "You must fill all required filed ");
                return View(socialVModel);
            }
            else
            {
                try
                {
                    await _socialMedia.UpdateSocialMediaAsync(socialVModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(socialVModel);
                }

            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _socialMedia.DeleteSocialMediaAsync(id);
            if (!result.Status)
            {
                ModelState.AddModelError("", result.Message);
                return View();
            }

            return RedirectToAction(nameof(Index));


        }
    }
}
