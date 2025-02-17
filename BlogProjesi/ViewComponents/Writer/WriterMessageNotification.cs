using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogProjesi.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            int id= Convert.ToInt32(UserClaimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier));
            var values = mm.GetInboxListByWriter(id);
            return View(values);

        }
    }
}
