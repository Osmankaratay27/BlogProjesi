using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            //BlogManager bm = new BlogManager(new EfBlogRepository());

            //var values=bm.GetList();
            return View();
        }
    }
}
