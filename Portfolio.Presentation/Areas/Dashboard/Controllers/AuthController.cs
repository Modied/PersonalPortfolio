using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Domain.Models;
using System.Security.Claims;
using static Azure.Core.HttpHeader;

namespace Portfolio.Presentation.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AuthController : Controller
    {
        private readonly IAuth _authService;
        private readonly IPersonalInfo _personalInfo;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(IAuth authService, IPersonalInfo personalInfo, UserManager<ApplicationUser> userManager)
        {
            _authService = authService;
            _personalInfo = personalInfo;
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<ActionResult> Login()
        {
            return View(new LoginVModel { });
        }

        [HttpPost]

        public async Task<IActionResult> Login(LoginVModel loginVModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVModel);
            }

            var authModel = await _authService.LoginAsync(loginVModel);

            if (!authModel.isAouthentecated)
            {
                ModelState.AddModelError(string.Empty, authModel.Message);
                return View(loginVModel);
            }

            if (User.Identity.IsAuthenticated)
            {

                return RedirectToAction("Index", "PersonalInfo", new { area = "Dashboard" });
            }

            return RedirectToAction("AccessDenied", "Auth", new { area = "Dashboard" });
        }

        public async Task<IActionResult> AccessDenied()
        {
            return View(); // Create a simple AccessDenied.cshtml view
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View("Register", new RegisterVModel { });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVModel registerVModel)
        {
            if (!ModelState.IsValid)
            {

                return View(registerVModel);
            }
            var authModel = await _authService.RegisterAsync(registerVModel);
            if (!authModel.isAouthentecated)
            {
                ModelState.AddModelError(string.Empty, authModel.Message);
                return View(registerVModel);
            }

            return RedirectToAction("Login", new LoginVModel { });

        }


    }
}
