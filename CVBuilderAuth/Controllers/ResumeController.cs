using Microsoft.AspNetCore.Mvc;

namespace CVBuilderAuth.Controllers
{
	public class ResumeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
