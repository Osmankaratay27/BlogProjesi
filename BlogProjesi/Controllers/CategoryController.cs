using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            CategoryManager cm=new CategoryManager(new EfCategoryRepository());

            var values = cm.GetList();
            return View(values);
        }
    }
}
