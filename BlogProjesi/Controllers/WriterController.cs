using BlogProjesi.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace BlogProjesi.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
        public IActionResult WriterNavbarPartial()
        {
            return PartialView();
        }
        public IActionResult WriterFooterPartial()
        {
            return PartialView();
        }
        public IActionResult WriterProfile()
        {
            var values = wm.GetByFilter(User.Identity.Name);
            return View(values);
        }
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var values = wm.GetByFilter(User.Identity.Name);
            return View(values);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
            var pas1 = Request.Form["pass1"];
            var pas2 = Request.Form["pass2"];
            if (pas1 == pas2)
            {
                p.WriterPassword = pas2;
                WriterValidator wl = new WriterValidator();
                ValidationResult results = wl.Validate(p);
                if (results.IsValid)
                {
                    wm.TUpdate(p);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else
            {
                ViewBag.hata = "Şifreler Uyuşmuyor !";
            }
            return View();
        }
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();

            var pas1 = Request.Form["pass1"];
            var pas2 = Request.Form["pass2"];
            if (pas1 == pas2)
            {
                p.WriterPassword = pas2;

                if (p.WriterImage != null)
                {
                    var extension = Path.GetExtension(p.WriterImage.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    p.WriterImage.CopyTo(stream);
                    w.WriterImage = newImageName;
                }
                w.WriterMail = p.WriterMail;
                w.WriterName = p.WriterName;
                w.WriterPassword = p.WriterPassword;
                w.WriterStatus = true;
                w.WriterAbout = p.WriterAbout;
                wm.TAdd(w);

                return RedirectToAction("Index", "Dashboard");


            }
            else
            {
                ViewBag.hata = "Şifreler Uyuşmuyor !";
            }
            return View();
        }
    }
}
