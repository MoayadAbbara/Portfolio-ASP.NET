using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MoayadPortfolio.Controllers
{
    [Authorize]
    public class SkillController : Controller
    {
        public IActionResult AddNewSkill(DTO.Request.Skills skill)
        {
            BusinessLayer.Skills.AddSkill(skill);
            return RedirectToAction("Index", "AdminPanel");
        }

        public IActionResult DeleteSkill(int id)
        {
            BusinessLayer.Skills.DeleteSkill(id);
            return RedirectToAction("Index", "AdminPanel");
        }


        public JsonResult GetSkillDetails(int id)
        {
            var skill = BusinessLayer.Skills.GetSkillById(id);
            return Json(skill);
        }

        public IActionResult EditSkill(DTO.Request.Skills skill)
        {
            BusinessLayer.Skills.EditSkill(skill);
            return RedirectToAction("Index", "AdminPanel");
        }
    }
}
