using Microsoft.AspNetCore.Mvc;

namespace MoayadPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult AddNewService(DTO.Request.Services NewService)
        {
            BusinessLayer.Services.AddService(NewService);
            return RedirectToAction("Index", "AdminPanel");
        }


        public IActionResult DeleteService(int id)
        {
            BusinessLayer.Services.DeleteService(id);
            return RedirectToAction("Index", "AdminPanel");
        }
    }
}
