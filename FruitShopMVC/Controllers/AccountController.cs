using FruitShopMVC.Helper;
using FruitShopMVC.Models;
using FruitShopMVC.ViewModels.AccountVm;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FruitShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager)
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
        public async  Task<IActionResult> Register(RegisterVm vm) {
            if (!ModelState.IsValid)
            {
                return View();
            }     
            AppUser user = new AppUser()
            {
                Name = vm.Name,
                Surname = vm.Surname,
                UserName = vm.UserName,
                Email = vm.Email,
            };
            var res =await _userManager.CreateAsync(user,vm.Password);
            if (!res.Succeeded)
            {
                foreach (var item in res.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(vm);
            };
            await _userManager.AddToRoleAsync(user,UserRole.Admin.ToString());
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
            AppUser user = await _userManager.FindByNameAsync(vm.UserNameOrEmail) ?? (await _userManager.FindByEmailAsync(vm.UserNameOrEmail));
            if (user == null)
            {
                ModelState.AddModelError("","Username/email or password is wrong");
                return View(vm);
            }
            var res = await _signInManager.PasswordSignInAsync(user,vm.Password,true,false);
            if(!res.Succeeded)
            {
                ModelState.AddModelError("", "Username/email or password is wrong");
                return View(vm);
            }

            return RedirectToAction("Index","Home");
        }

        public async Task <ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> CreateRole()
        {
            foreach (var item in Enum.GetValues(typeof(UserRole)))
            {
                if( await _roleManager.FindByNameAsync(item.ToString()) == null)
                {
                    await _roleManager.CreateAsync(new IdentityRole()
                    {
                        Name = item.ToString()
                    });   
                }
            } 
            return RedirectToAction("Index", "Home");
        }
         
    }
}
