using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MoayadPortfolio.Controllers
{
    [Authorize]
    public class EducationController : Controller
    {
        public IActionResult AddNewEducation(DTO.Request.Education NewEducation)
        {
            BusinessLayer.Education.AddEducation(NewEducation);
            return RedirectToAction("Index", "AdminPanel");
        }

        public IActionResult DeleteEducation(int id)
        {
            BusinessLayer.Education.DeleteEducation(id);
            return RedirectToAction("Index", "AdminPanel");
        }
    }
}
