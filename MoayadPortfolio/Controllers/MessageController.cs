using Microsoft.AspNetCore.Mvc;

namespace MoayadPortfolio.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult SendMessage(DTO.Request.Message message)
        {
            BusinessLayer.Messages.SendMessage(message);
            return RedirectToAction("Index","Home");
        }
    }
}
