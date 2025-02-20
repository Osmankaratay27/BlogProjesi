using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCommentController : Controller
    {
        CommentManager cm= new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            var values = cm.GetCommentListWithBlog();
            return View(values);
        }
    }
}
