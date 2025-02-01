using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        public IActionResult Inbox()
        {
            int id = 1;
            var values = mm.GetInboxListByWriter(id);
            return View(values);

        }
        public IActionResult MessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }
    }
}
