using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CVBuilderAuth.Models;
using Microsoft.AspNetCore.Identity;
using CVBuilderAuth.Models.Domain;
using System.Security.Claims;

namespace CVBuilderAuth.Controllers
{
	public class ResumeController : Controller
	{
		ApplicationContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        public ResumeController(ApplicationContext context, UserManager<ApplicationUser> userManager)
		{
			db = context;
            _userManager = userManager;
        }

		public IActionResult Create() 
		{
			return View();
		}

        [HttpPost]
		public async Task<IActionResult> Create(UserCvInfo userCvInfo)
		{
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            userCvInfo.UserId = userId;


            db.UserCvInfos.Add(userCvInfo);
			await db.SaveChangesAsync();
			return RedirectToAction("CreateExperience");

		}
		public IActionResult CreateExperience() 
				{
					return View();
				}
        [HttpPost]
        public async Task<IActionResult> CreateExperience(CvExperience cvExperience)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            cvExperience.UserId = userId;

            db.CvExperiences.Add(cvExperience);
            await db.SaveChangesAsync();
            return RedirectToAction("CreateLanguage");

        }

        public IActionResult CreateLanguage()
        {
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> CreateLanguage(CvLanguageSkill cvLanguageSkill)
		{
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            cvLanguageSkill.UserId = userId;

            db.CvLanguageSkills.Add(cvLanguageSkill);
			await db.SaveChangesAsync();
			return RedirectToAction("CreateSkill");
		}

        public IActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSkill(CvSkill cvSkill)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            cvSkill.UserId = userId;

            db.CvSkills.Add(cvSkill);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult CV()
		{
			return View();
		}




	}
}
