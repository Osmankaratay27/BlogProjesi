using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.BlogCount = c.Blogs.Count();
            ViewBag.WriterBlogCount = c.Blogs.Count(x=>x.WriterID==1);
            ViewBag.CategoryCount = c.Categories.Count();
            return View();
        }
    }
}
