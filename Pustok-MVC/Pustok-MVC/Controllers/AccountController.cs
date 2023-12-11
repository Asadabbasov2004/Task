using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pustok_MVC.ViewModels.Account;

namespace Pustok_MVC.Controllers
{
	[AutoValidateAntiforgeryToken]
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterVm registerVm)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			AppUser user = new AppUser()
			{
				Name = registerVm.Name,
				Email = registerVm.Email,
				Surname = registerVm.Surname,
				UserName = registerVm.UserName,

			};
			var result = await _userManager.CreateAsync(user, registerVm.Password);
			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
				return View();
			}
			await _signInManager.SignInAsync(user, false);
			return RedirectToAction(nameof(Index), "Home");
		}
		public IActionResult Login()
		{
			return View();
		}
		//[HttpPost]
  //      public IActionResult Login(LoginVm loginvm)
  //      {
		//	if (!ModelState.IsValid)
		//	{ return View(); }

  //          return View();
  //      }
        public IActionResult LogOut()
		{
			_signInManager.SignOutAsync();
			return RedirectToAction(nameof(Index),"Home");
		}
	}
	
	/*[AutoValidateAntiforgeryToken]
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterVm registerVm)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			AppUser user = new AppUser()
			{
				Name = registerVm.Name,
				Email = registerVm.Email,
				Surname = registerVm.Surname,
				UserName = registerVm.UserName,

			};
			var result = await _userManager.CreateAsync(user, registerVm.Password);
			if (result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
				return View();
			}
			await _signInManager.SignInAsync(user, false);
			return RedirectToAction(nameof(Index), "Home");
		}
		public IActionResult Login()
		{
			return View();
		}
		public IActionResult LogOut()
		{
			return View();
		}
	}*/
}
