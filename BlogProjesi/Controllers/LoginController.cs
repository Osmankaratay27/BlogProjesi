using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
