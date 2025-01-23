using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
        public IActionResult WriterNavbarPartial()
        {
            return PartialView();
        }
        public IActionResult WriterFooterPartial()
        {
            return PartialView();
        }
    }
}
