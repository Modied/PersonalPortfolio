using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Presentation.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        private readonly IService _services;

        public ServiceController(IService services)
        {
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _services.GetAllServicesAsync();
            return View(services);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new ServiceVModel { });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceVModel serviceVModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "You must fill all required filed ");
                return View(serviceVModel);
            }
            try
            {
                await _services.AddServiceAsync(serviceVModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var service = await _services.GetServiceByIdAsync(id);
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ServiceVModel serviceVModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "You must fill all required filed ");
                return View(serviceVModel);
            }
            try
            {
                await _services.UpdateServiceAsync(serviceVModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _services.DeleteServiceAsync(id);

            if (!result.Status)
            {
                ModelState.AddModelError("", result.Message.ToString());
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
