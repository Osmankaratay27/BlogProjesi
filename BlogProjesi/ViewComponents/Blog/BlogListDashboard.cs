using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.ViewComponents.Blog
{
    public class BlogListDashboard:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = bm.GetBlogListWithCategory().TakeLast(10).ToList();
            //var values = bm.GetBlogListWithCategory().OrderByDescending(x => x.BlogID).Take(10).ToList(); -> yapılabilir

            return View(values);
        }
    }
}
