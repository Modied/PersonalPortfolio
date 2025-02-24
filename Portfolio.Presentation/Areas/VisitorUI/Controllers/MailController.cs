using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Presentation.Areas.VisitorUI.Controllers
{
    [Area("VisitorUI")]
    public class MailController : Controller
    {
        private readonly IMail _mail;

        public MailController(IMail mail)
        {
            _mail = mail;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMail(MailVModel mailVModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "You Should Fill All Filed");
                return RedirectToAction("Index", "Home", new { Areas = "VisitorUI" });
            }

            await _mail.SendEmailAsync(mailVModel);
            return RedirectToAction("Index", "Home", new { Areas = "VisitorUI" });
            //throw new NotImplementedException();
        }

    }
}
