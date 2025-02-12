
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager wm=new WriterManager(new EfWriterRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
    
            var userName = User.Identity.Name;
            var userMail= c.Users.Where(x=>x.UserName == userName).Select(x=>x.Email).FirstOrDefault();
            var values = wm.GetByFilter(userMail);
            return View(values);
        }
    }
}
