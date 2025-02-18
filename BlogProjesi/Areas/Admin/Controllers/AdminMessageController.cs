using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogProjesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        public IActionResult Inbox()
        {
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var values = mm.GetInboxListByWriter(id);
            return View(values);
        }
        public IActionResult Sendbox()
        {
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var values = mm.GetSendboxListByWriter(id);
            return View(values);

        }
        public IActionResult ComposeMessage()
        {
            return View();  
        }
    }
}
