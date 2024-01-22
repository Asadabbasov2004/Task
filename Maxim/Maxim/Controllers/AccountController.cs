using Maxim.Helper;
using Maxim.Models;
using Maxim.ViewModels.AccountVm;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Maxim.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

      
        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager ,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm vm)
        {
                if (!ModelState.IsValid)
                {
                    return View(vm);
                }
                AppUser user = new AppUser()
                {
                    Name = vm.Name,
                    Email = vm.Email,
                    Surname = vm.Surname,
                    UserName = vm.UserName,
                };
               var result = await _userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded)
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                };
                return View(vm);
            }
            await _userManager.AddToRoleAsync(user,"Member");
                return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm vm,string? returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var user = await _userManager.FindByNameAsync(vm.UserNameOrEmail) ?? await _userManager.FindByEmailAsync(vm.UserNameOrEmail);
            if (user == null) 
            { 
                ModelState.AddModelError("", "Username/Email or password"); 
                return View(vm);
            }
            var res = await _signInManager.PasswordSignInAsync(user, vm.Password, true, false);
            if (!res.Succeeded)
            {
                ModelState.AddModelError("", "Username/Email or password");
                return View(); 
            }
            return (returnUrl is not null && returnUrl.Contains("Login")) ? RedirectToAction(nameof(Index), "Home") : Redirect(returnUrl);
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
