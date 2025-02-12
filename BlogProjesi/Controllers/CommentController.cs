using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
	[AllowAnonymous]
	public class CommentController : Controller
	{
		CommentManager cm = new CommentManager(new EfCommentRepository());
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
		[HttpPost]
        public PartialViewResult PartialAddComment(Comment p)
        {
			p.CommentStatus = true;
			p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			p.BlogID = 8;
			cm.CommentAdd(p);
            Response.Redirect("/Blog/BlogReadAll/"+p.BlogID+"");
            return PartialView();
        }

        public PartialViewResult CommentListByBlog(int id)
		{
			var values = cm.GetList(id);
			return PartialView(values);
		}
	}
}
