using BusinessLayer;
using DataLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using MoayadPortfolio.Models;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<DTO.Response.Facts> FactsList = BusinessLayer.Facts.getFactsList();
            List<DTO.Response.Skills> SkillsList = BusinessLayer.Skills.getSkillsList();
            List<DTO.Response.Services> ServicesList = BusinessLayer.Services.getServicesList();
            List<DTO.Response.Education> EducationList = BusinessLayer.Education.getEducationList();
            List<DTO.Response.Experience> ExperienceList = BusinessLayer.Experience.getExperienceList();
            List<DTO.Response.ProjectTypes> ProjectTypesList = BusinessLayer.Projects.getProjectCategories();
            List<DTO.Response.Projects> ProjectsList = BusinessLayer.Projects.getProjectList();
            var HomePageTuple = (FactsList , SkillsList , ServicesList , EducationList , ExperienceList , ProjectTypesList , ProjectsList);
            return View(HomePageTuple);
        }
    }
}
