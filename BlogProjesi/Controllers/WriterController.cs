using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository()); 
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
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var values = wm.GetById(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
            return View();
        }
    }
}
