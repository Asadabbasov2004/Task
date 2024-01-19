using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using we.Exceptions;
using we.Models;
using we.ViewModels.Account;

namespace we.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
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
        public  async Task<IActionResult> Register(RegisterVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = new AppUser()
            {
                Name = vm.Name,
                Surname = vm.Surname,
                Email = vm.Email,
                UserName = vm.UserName,
            };
          
           var  res = await _userManager.CreateAsync(user, vm.Password);
            if (!res.Succeeded)
            {
                foreach (var item in res.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            return RedirectToAction(nameof(Login));
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
            var user = await _userManager.FindByEmailAsync(vm.UsernameOrEmail)?? (await _userManager.FindByNameAsync(vm.UsernameOrEmail));
            if(user == null)
            {
                ModelState.AddModelError("", "urhquwe");
                return View();
            }
            var res = await _signInManager.PasswordSignInAsync(user, vm.Password,true,false);
            if (!res.Succeeded)
            {
                ModelState.AddModelError("", "urhquwe");
                return View();
            }
            await _signInManager.SignInAsync(user,true);
            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        //public async Task<IActionResult> CreateRole()
        //{


        //};
    }
    }


