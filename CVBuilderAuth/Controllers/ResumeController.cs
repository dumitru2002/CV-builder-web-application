using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CVBuilderAuth.Models;

namespace CVBuilderAuth.Controllers
{
	public class ResumeController : Controller
	{
		ApplicationContext db;
		public ResumeController(ApplicationContext context)
		{
			db = context;
		}

		public IActionResult Create() 
		{
			return View();
		}

		

		[HttpPost]
		public async Task<IActionResult> Create(UserCvInfo userCvInfo)
		{
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
