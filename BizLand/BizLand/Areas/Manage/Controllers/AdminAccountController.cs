using BizLand.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BizLand.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AdminAccountController : Controller
    {
        private readonly UserManager<AppUser> _usermanager;
        private readonly SignInManager<AppUser> _signinmanager;
        private readonly RoleManager<IdentityRole> _rolemanager;

        public AdminAccountController(SignInManager<AppUser> signinmanager, UserManager<AppUser> usermanager, RoleManager<IdentityRole> rolemanager)
        {
            _signinmanager = signinmanager;
            _usermanager = usermanager;
            _rolemanager = rolemanager;
        }

        public async Task<IActionResult> Index()
        {
            //AppUser admin = new AppUser()
            //{
            //	UserName = "admin",
            //	FullName = "admin",
            //};
            //var result = await _usermanager.CreateAsync(admin, "Admin123");
            //if (!result.Succeeded)
            //{
            //	foreach (var item in result.Errors)
            //	{
            //		ModelState.AddModelError("", item.Description);
            //	}
            //	return View();
            //}


            //await _rolemanager.CreateAsync(new IdentityRole("admin"));
            //await _rolemanager.CreateAsync(new IdentityRole("member"));


            //var user = await _usermanager.FindByNameAsync("admin");
            //await _usermanager.AddToRoleAsync(user, "admin");
            //await _signinmanager.SignInAsync(user, false);
            return Json(":)");
        }
    }
}