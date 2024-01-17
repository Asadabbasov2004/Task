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
                    return View();
                }
                AppUser user = new AppUser()
                {
                    Name = vm.Name,
                    Email = vm.Email,
                    Surname = vm.Surname,
                    UserName = vm.UserName,
                };
                //var result = await _userManager.CreateAsync(user);
                //if (!result.Succeeded) throw new Exception();
               var result = await _userManager.CreateAsync(user, vm.Password);
                if (result == null) throw new Exception();
                return RedirectToAction("Login");

        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userManager.FindByNameAsync(vm.UserNameOrEmail);
            if(user is null)
            {
                user = await _userManager.FindByEmailAsync(vm.UserNameOrEmail);
                if (user == null) throw new Exception("parametr is false");
                if( !await _userManager.CheckPasswordAsync(user, vm.Password)) throw new Exception();
            }
            await _signInManager.SignInAsync(user,false);
            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
