using Microsoft.AspNetCore.Mvc;

namespace MoayadPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult AddNewProject(DTO.Request.Projects NewProject)
        {
            BusinessLayer.Projects.AddProject(NewProject);
            return RedirectToAction("Index", "AdminPanel");
        }

        public IActionResult DeleteProject(int id)
        {
            BusinessLayer.Projects.DeleteProject(id);
            return RedirectToAction("Index", "AdminPanel");
        }

        public JsonResult GetProjectDetails(int id)
        {
            var Project = BusinessLayer.Projects.GetProjectById(id);
            return Json(Project);
        }

        public IActionResult EditProject(DTO.Request.Projects project)
        {
            BusinessLayer.Projects.EditProject(project);
            return RedirectToAction("Index", "AdminPanel");
        }

        public IActionResult AddNewImage(DTO.Request.NewProjectImage image)
        {
            BusinessLayer.Projects.AddNewImage(image);
            return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminPanel") });
        }
    }
}
