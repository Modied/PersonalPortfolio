using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Domain.Models;

namespace Portfolio.Presentation.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class CompanyController : Controller
    {
        private readonly ICompany _company;

        public CompanyController(ICompany company)
        {
            _company = company;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _company.GetAllCompaniesAsync();
            return View(result);

        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _company.GetCompanyAsync(id);
            return View("View", result);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View(new CompanyVModel { });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyVModel companyVModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "You must fill all required filed ");
                return View();
            }
            else
            {
                try
                {
                    await _company.AddCompanyAsync(companyVModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(companyVModel);
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _company.GetCompanyAsync(id);
            return View(result);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CompanyVModel companyVModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "You must fill all required filed ");
                return View(companyVModel);
            }
            else
            {
                try
                {
                    await _company.UpdateCompanyAsync(companyVModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(companyVModel);
                }
            }

        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _company.DeleteCompanyAsync(id);
            if (!result.Status)
            {
                ModelState.AddModelError("", result.Message.ToString());
                return View();
            }

            return RedirectToAction(nameof(Index));

        }
    }
}
