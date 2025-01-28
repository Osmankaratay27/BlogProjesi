using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
