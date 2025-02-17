using BlogProjesi.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace BlogProjesi.Controllers
{
    public class WriterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        WriterManager wm = new WriterManager(new EfWriterRepository());
        Context c = new Context();

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

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
        [HttpGet]
        public async Task<IActionResult> WriterProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.namesurname = values.NameSurname;
            model.username = values.UserName;
            model.imageurl = values.ImageUrl;
            model.mail = values.Email;


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.NameSurname = model.namesurname;
            values.UserName = model.username;
            values.Email = model.mail;
            values.ImageUrl = model.imageurl;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values,model.password);
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");
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
