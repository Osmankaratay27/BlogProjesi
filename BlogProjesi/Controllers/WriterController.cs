using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
