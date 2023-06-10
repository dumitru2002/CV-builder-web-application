using CVBuilderAuth.Models;
using CVBuilderAuth.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CVBuilderAuth.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        ApplicationContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        public DashboardController(ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            db = context;
            _userManager = userManager;
        }
        public IActionResult Display()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            UserCvInfo userCvInfo = db.UserCvInfos.FirstOrDefault(u => u.UserId == userId);
            if (userCvInfo == null)
            {
                
                return View(true);
            }
            else
            {
               
                return View(false);
            }
        }

        

    }
}
