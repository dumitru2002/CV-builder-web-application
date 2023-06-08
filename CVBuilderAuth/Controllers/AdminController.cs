using CVBuilderAuth.Models.DTO;
using CVBuilderAuth.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CVBuilderAuth.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        public IActionResult Display()
        {
            return View();
        }

        private readonly IUserAuthenticationService _service;
        public AdminController(IUserAuthenticationService service)
        {
            this._service = service;
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(RegistrationModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _service.RegistrationAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Display));
        }
    }
}
