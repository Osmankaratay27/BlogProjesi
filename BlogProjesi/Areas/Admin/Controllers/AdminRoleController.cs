using BlogProjesi.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace BlogProjesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public AdminRoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> AddRole(RoleViewModel p)
        {
            if (ModelState.IsValid)
            {
                AppRole role=new AppRole
                {
                    Name=p.name
                };

                var result =await _roleManager.CreateAsync(role);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values=_roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleUpdateViewModel model = new RoleUpdateViewModel
            {
                Id = values.Id,
                name = values.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model)
        {
            var values = _roleManager.Roles.Where(x => x.Id == model.Id).FirstOrDefault();

            values.Name = model.name;
            var result = await _roleManager.UpdateAsync(values);
            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }
          
            return View(model);
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var values=_roleManager.Roles.FirstOrDefault(x=>x.Id == id);
            var result=await _roleManager.DeleteAsync(values); 
            if(result.Succeeded) 
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
