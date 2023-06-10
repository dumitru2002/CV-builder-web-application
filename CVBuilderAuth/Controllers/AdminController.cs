﻿using CVBuilderAuth.Models.Domain;
using CVBuilderAuth.Models.DTO;
using CVBuilderAuth.Models;
using CVBuilderAuth.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CVBuilderAuth.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        public IActionResult Display()
        {
            return View();
        }








        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserAuthenticationService _service;
        public AdminController(IUserAuthenticationService service, UserManager<ApplicationUser> userManager)
        {
            this._service = service;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = userManager.Users;
            return View(users);
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

        private DatabaseContext db = new DatabaseContext(); 

        public ActionResult ShowUser()
        {
            var users = db.Users.ToList();
            return View(users);
        }




        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListUsers");
            }
        }
    }
}