using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CVBuilderAuth.Models;
using Microsoft.AspNetCore.Identity;
using CVBuilderAuth.Models.Domain;
using System.Security.Claims;
using CVBuilderAuth.Migrations.Application;

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
            return RedirectToAction("CreateEducation");

        }

        public IActionResult CreateEducation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEducation(CvEducation cvEducation)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            cvEducation.UserId = userId;

            db.CvEducations.Add(cvEducation);
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
            return RedirectToAction("Show");
        }

        public IActionResult Show()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = new CombinedViewModel();
            viewModel.UserCvInfoData = db.UserCvInfos.Where(u => u.UserId == userId).ToList();
            viewModel.CvExperienceData = db.CvExperiences.Where(c => c.UserId == userId).ToList();
            viewModel.CvLanguageSkillData = db.CvLanguageSkills.Where(l => l.UserId == userId).ToList();
            viewModel.CvSkillsData = db.CvSkills.Where(s => s.UserId == userId).ToList();
            viewModel.CvEducationData = db.CvEducations.Where(s => s.UserId == userId).ToList();

            return View(viewModel );
        }

        public IActionResult CV()
        {
            return View();
        }



        [HttpGet]
        public ActionResult Edit()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            UserCvInfo userCvInfo = db.UserCvInfos.FirstOrDefault(u => u.UserId == userId);
            return View(userCvInfo);
        }

        [HttpPost]
        public ActionResult Edit(UserCvInfo userCvInfo)
        {
            db.Entry(userCvInfo).State = EntityState.Modified;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            userCvInfo.UserId = userId;
            db.SaveChanges();
            return RedirectToAction("Show");
        }





    }
}
