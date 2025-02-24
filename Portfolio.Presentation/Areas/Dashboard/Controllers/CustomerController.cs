using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Presentation.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class CustomerController : Controller
    {
        private readonly ICustomer _customer;

        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _customer.GetAllCustomersAsync();
            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _customer.GetCustomerAsync(id);
            return View(result);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View(new CustomerVModel { });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerVModel customerVModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "You must fill all required filed ");
                return View(RedirectToAction(nameof(Create)));
            }
            else
            {
                try
                {
                    await _customer.AddCustomerAsync(customerVModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(customerVModel);
                }
            }
        }
        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _customer.GetCustomerAsync(id);
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CustomerVModel customerVModel)
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
                    await _customer.UpdateCustomerAsync(customerVModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(customerVModel);
                }

            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _customer.DeleteCustomerAsync(id);
            if (!result.Status)
            {
                ModelState.AddModelError("", result.Message.ToString());
                return View();
            }

            return RedirectToAction(nameof(Index));

        }
    }
}
