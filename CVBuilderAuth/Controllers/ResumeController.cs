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
			return RedirectToAction("Index", "Home");
		}


		public IActionResult CV()
		{
			return View();
		}




	}
}
