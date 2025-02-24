using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.ViewModels;

namespace Portfolio.Presentation.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class ToolController : Controller
    {
        private readonly ITool _tool;
        public ToolController(ITool tool)
        {
            _tool = tool;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _tool.GetAllToolsAsync();
            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _tool.GetToolAsync(id);
            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new ToolVModel { });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToolVModel toolVModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "You must fill all required filed ");
                return View(toolVModel);
            }
            else
            {
                try
                {
                    await _tool.AddToolAsync(toolVModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(toolVModel);
                }
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _tool.GetToolAsync(id);
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ToolVModel toolVModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "You must fill all required filed ");
                return View(toolVModel);
            }
            else
            {
                try
                {
                    await _tool.UpdateToolAsync(toolVModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(toolVModel);
                }
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tool.DeleteToolAsync(id);
            if (!result.Status)
            {
                ModelState.AddModelError("", result.Message.ToString());
                return View();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
