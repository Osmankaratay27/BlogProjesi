using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
    
            return View();

        }
    }
}
