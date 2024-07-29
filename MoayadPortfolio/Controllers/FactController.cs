using Microsoft.AspNetCore.Mvc;

namespace MoayadPortfolio.Controllers
{
    public class FactController : Controller
    {
        public IActionResult AddNewFact(DTO.Request.Facts NewFact)
        {
            BusinessLayer.Facts.AddFact(NewFact);
            return RedirectToAction("Index", "AdminPanel");
        }


        public IActionResult DeleteFact(int id)
        {
            BusinessLayer.Facts.DeleteFact(id);
            return RedirectToAction("Index", "AdminPanel");
        }

        public JsonResult GetFactDetails(int id)
        {
            var Fact = BusinessLayer.Facts.GetFactById(id);
            return Json(Fact);
        }

        public IActionResult EditFact(DTO.Request.Facts NewFact)
        {
            BusinessLayer.Facts.EditFact(NewFact);
            return RedirectToAction("Index", "AdminPanel");
        }
    }
}
