using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
