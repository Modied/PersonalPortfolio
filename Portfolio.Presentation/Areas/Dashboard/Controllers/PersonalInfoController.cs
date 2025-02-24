using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Portfolio.Presentation.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class PersonalInfoController : Controller
    {
        private readonly IPersonalInfo _personalInfo;
        //public static string viewPath = Path.Combine("Views", "Dashboard", "PersonalInfo ");
        public PersonalInfoController(IPersonalInfo personalInfo)
        {
            _personalInfo = personalInfo;

        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var user = User.Identity.IsAuthenticated ? "Authenticated" : "Not Authenticated";
            var roles = User.IsInRole("Admin") ? "Admin" : "Not Admin";

            Console.WriteLine($"User Authentication: {user}");
            Console.WriteLine($"User Role: {roles}");
            var result = await _personalInfo.GetPersonalInfoAsync();
            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _personalInfo.GetPersonalInfoByIDAsync(id);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("Create", new PersonalInfoVModel { });
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonalInfoVModel personalInfoVModel)
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
                    await _personalInfo.AddPersonalInfoAsync(personalInfoVModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View("Create");
                }
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            var result = await _personalInfo.GetPersonalInfoByIDAsync(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(PersonalInfoVModel personalInfoVModel)
        {
            // Console.WriteLine("Model State is not valid");

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "You must fill all required filed");

                return View(personalInfoVModel);
            }
            else
            {
                try
                {

                    await _personalInfo.UpdatePersonalInfoAsync(personalInfoVModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(personalInfoVModel);
                }

            }
        }


        public async Task<IActionResult> Delete(int id)
        {

            var result = await _personalInfo.DeletePersonalInfoAsync(id);
            if (!result.Status)
            {
                ModelState.AddModelError("", result.Message.ToString());
                return View();
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
