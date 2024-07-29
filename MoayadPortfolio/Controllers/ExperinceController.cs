using Microsoft.AspNetCore.Mvc;

namespace MoayadPortfolio.Controllers
{
    public class ExperinceController : Controller
    {
        public IActionResult AddNewExperince(DTO.Request.Experience experience)
        {
            BusinessLayer.Experience.AddExperince(experience);
            return RedirectToAction("Index", "AdminPanel");
        }

        public IActionResult DeleteSkill(int id)
        {
            BusinessLayer.Experience.DeleteExperince(id);
            return RedirectToAction("Index", "AdminPanel");
        }
    }
}
