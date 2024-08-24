using BlogProjesi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.ViewComponents
{
	public class CommentList:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var comments = new List<UserComment>
			{
				new UserComment
				{
					Id = 1,
					Name="Osman"
				},
				new UserComment
				{
					Id = 2,
					Name="Ali"
				},
				new UserComment
				{
					Id = 3,
					Name="Mehmet"
				}
			};
			return View(comments);
		}
	}
}
