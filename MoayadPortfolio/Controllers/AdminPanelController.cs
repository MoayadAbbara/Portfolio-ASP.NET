using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MoayadPortfolio.Controllers
{
    [Authorize]
    public class AdminPanelController : Controller
    {
        public IActionResult Index()
        {
            List<DTO.Response.Facts> FactsList = BusinessLayer.Facts.getFactsList();
            List<DTO.Response.Skills> SkillsList = BusinessLayer.Skills.getSkillsList();
            List<DTO.Response.Services> ServicesList = BusinessLayer.Services.getServicesList();
            List<DTO.Response.Education> EducationList = BusinessLayer.Education.getEducationList();
            List<DTO.Response.Experience> ExperienceList = BusinessLayer.Experience.getExperienceList();
            List<DTO.Response.Projects> ProjectsList = BusinessLayer.Projects.getProjectList();
            List<DTO.Response.ProjectTypes> ProjectTypesList = BusinessLayer.Projects.getProjectCategories();
            List<DTO.Response.Message> MessageList = BusinessLayer.Messages.getgetMessagesList();
            var AdminPanelTuple = (FactsList, SkillsList, ServicesList, EducationList, ExperienceList, ProjectsList, ProjectTypesList,MessageList);
            return PartialView(AdminPanelTuple);
        }
    }
}
