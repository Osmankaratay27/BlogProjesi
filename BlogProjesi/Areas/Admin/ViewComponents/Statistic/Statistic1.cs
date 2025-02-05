using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BlogProjesi.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        BlogManager bm= new BlogManager(new EfBlogRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.BlogCount=bm.GetList().Count();
            ViewBag.MessageCount=c.Contacts.Count();
            ViewBag.CommentCount=c.Comments.Count();

            string api = "fefedcd91fcba23ee66046a05c4d49f3";
            string city = "istanbul";
            string connection= "https://api.openweathermap.org/data/2.5/weather?q="+city+"&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document= XDocument.Load(connection);
            ViewBag.WheatherTemperature = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            return View();
        }
    }
}
