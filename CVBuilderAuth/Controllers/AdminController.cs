using CVBuilderAuth.Models.Domain;
using CVBuilderAuth.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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


        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Action method to handle the new user registration form submission
        [HttpPost]
        public async Task<IActionResult> AddUser(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username, Email = model.Email };

                // Create the user
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Add the user to the selected role
                    await _userManager.AddToRoleAsync(user, model.Role);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Handle the errors if the user creation fails
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            // If the model state is not valid, return the registration view with validation errors
            return View(model);
        }
    }
}
