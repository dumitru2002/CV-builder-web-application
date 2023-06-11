using CVBuilderAuth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using IronPdf;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using CVBuilderAuth.Models.Domain;

namespace CVBuilderAuth.Controllers
{
    public class DownloadController : Controller
    {
        ApplicationContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        public DownloadController(ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            db = context;
            _userManager = userManager;
        }
        public IActionResult PdfShow(UseTemplate useTemplate)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = new CombinedViewModel();
            model.UserCvInfoData = db.UserCvInfos.Where(u => u.UserId == userId).ToList();
            model.CvExperienceData = db.CvExperiences.Where(c => c.UserId == userId).ToList();
            model.CvLanguageSkillData = db.CvLanguageSkills.Where(l => l.UserId == userId).ToList();
            model.CvSkillsData = db.CvSkills.Where(s => s.UserId == userId).ToList();
            model.CvEducationData = db.CvEducations.Where(s => s.UserId == userId).ToList();

            ViewBag.TemplateId = db.UseTemplates.FirstOrDefault(u => u.UserId == userId)?.Template;

            var html = this.RenderViewAsync("_ShowPdf", model);
            var ironPdfRender = new IronPdf.ChromePdfRenderer();
            using var pdfDoc = ironPdfRender.RenderHtmlAsPdf(html.Result);
            return File(pdfDoc.Stream.ToArray(), "application/pdf");
        }
    }

    public static class ControllerPDF
    {
        public static async Task<string> RenderViewAsync<TModel>(this Controller controller, string viewName, TModel model, bool partial = false)
        {
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = controller.ControllerContext.ActionDescriptor.ActionName;
            }
            controller.ViewData.Model = model;
            using (var writer = new StringWriter())
            {
                IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewResult = viewEngine.FindView(controller.ControllerContext, viewName, true);
                if (viewResult.Success == false)
                {
                    return $"A view with the name {viewName} could not be found";
                }
                ViewContext viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, writer, new HtmlHelperOptions());
                await viewResult.View.RenderAsync(viewContext);
                return writer.GetStringBuilder().ToString();
            }
        }
    }

}
