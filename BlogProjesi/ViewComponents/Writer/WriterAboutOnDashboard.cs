using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager wm=new WriterManager(new EfWriterRepository());
        public IViewComponentResult Invoke()
        {

            var values = wm.GetByFilter(User.Identity.Name);
            return View(values);
        }
    }
}
