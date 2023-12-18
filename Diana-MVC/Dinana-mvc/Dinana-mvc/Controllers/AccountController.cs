using Azure.Identity;
using Dinana_mvc.Helpers;
using Dinana_mvc.Services;
using Dinana_mvc.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dinana_mvc
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private AppDbContext _db;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _db = db;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registervm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = new AppUser()
            {
                Name = registervm.Name,
                Email = registervm.Email,
                Surname = registervm.Surname,
                UserName = registervm.Username
            };

            var result = await _userManager.CreateAsync(user, registervm.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await _signInManager.SignInAsync(user, false);
            await _userManager.AddToRoleAsync(user, UserRole.Member.ToString());
            SendMailService.SendEmail(to: user.Email, name: user.Name);
            return RedirectToAction(nameof(Index), "Home");
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> LogIn(LoginVm loginvm, string? ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = await _userManager.FindByNameAsync(loginvm.EmailOrUsername);


            if (user is null)
            {
                user = await _userManager.FindByEmailAsync(loginvm.EmailOrUsername);

                if (user == null)
                {
                    ModelState.AddModelError("", "Username-Email ve ya  Password sehvdir");
                    return View();
                }
            }
            var result = _signInManager.CheckPasswordSignInAsync(user, loginvm.Password, true).Result;
            if (result.IsLockedOut)
            {
                ModelState.AddModelError(String.Empty, "Biraz sonra yeniden yoxla");
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username-Email or password is wrong");
                return View();
            }

            await _signInManager.SignInAsync(user, loginvm.RememberMe);

            if (ReturnUrl != null && !ReturnUrl.Contains("Login"))
            {
                return Redirect(ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }




        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> CreateRole()
        {
            foreach (UserRole item in Enum.GetValues(typeof(UserRole)))
            {
                if (await _roleManager.FindByNameAsync(item.ToString()) == null)
                {
                    await _roleManager.CreateAsync(new IdentityRole()
                    {
                        Name = item.ToString()
                    });

                }
            }
            return RedirectToAction("Index", "Home");
        }
        //[HttpPost]
        //public async Task<IActionResult> Subscribe(SubscribeVm subscribevm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    Subscribe subscribe = new Subscribe()
        //    {
        //        Id = subscribevm.Id,
        //        Email = subscribevm.Email,
        //    };
        //    await _db.Subscribes.AddAsync(subscribe);
        //    await _db.SaveChangesAsync();

        //    SendMailService.SendEmail(to: subscribevm.Email, name: "Diana App");

        //    return RedirectToAction("Index", "Home");
        //}
    }
}
