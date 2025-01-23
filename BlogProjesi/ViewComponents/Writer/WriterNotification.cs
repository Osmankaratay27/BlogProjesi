using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();

        }
    }
}
