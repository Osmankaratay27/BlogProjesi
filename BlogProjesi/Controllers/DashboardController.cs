using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class DashboardController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        public IActionResult Index()
        {
            Context c = new Context();
            var userName = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var writer = wm.GetByFilter(userMail);

            ViewBag.BlogCount = c.Blogs.Count();
            ViewBag.WriterBlogCount = c.Blogs.Count(x=>x.WriterID==writer.WriterID);
            ViewBag.CategoryCount = c.Categories.Count();
            return View();
        }
    }
}
