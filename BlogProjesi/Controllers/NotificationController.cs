using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
