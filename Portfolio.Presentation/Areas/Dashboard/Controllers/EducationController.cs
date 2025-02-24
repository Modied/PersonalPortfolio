using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Portfolio.Presentation.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class EducationController : Controller
    {
        private readonly IEducation _education;

        public EducationController(IEducation education)
        {
            _education = education;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _education.GetAllEducationsAsync(["EducationTypes"]);

            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _education.GetEducationAsync(id);
            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var result = await _education.CreateEducationAsync();
            return View(result);

        }

        [HttpPost]
        public async Task<IActionResult> Create(EducationVModel educationVModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "You must fill all required filed ");
                return View(educationVModel);
            }
            try
            {
                //  Console.WriteLine("EducationTypeId,{0},Id:{1},Major:{2},EndDate:{3},Degree:{4},EndDate:{5}", educationVModel.EducationTypeId, educationVModel.Id, educationVModel.Major, educationVModel.EndDate, educationVModel.Degree, educationVModel.EndDate);

                await _education.AddEducationAsync(educationVModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(educationVModel);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _education.GetEducationAsync(id);
            return View(result);
        }
        //  [HttpPut]
        public async Task<IActionResult> Update(EducationVModel educationVModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "You must fill all required filed ");
                return RedirectToAction("Edit", new { educationVModel.Id });
                //return View("Views/Dashboard/Education/Edit.cshtml", educationVModel);
            }
            else
            {
                try
                {
                    await _education.UpdateEducationAsync(educationVModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(educationVModel);
                }
            }
        }



        public async Task<IActionResult> Delete(int id)
        {
            var result = await _education.DeleteEducationAsync(id);

            if (!result.Status)
            {
                ModelState.AddModelError("", result.Message.ToString());
                return View();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
