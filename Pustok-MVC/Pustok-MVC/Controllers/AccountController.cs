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
		private readonly RoleManager<IdentityRole> _roleManager;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager)
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
			await _userManager.AddToRoleAsync(user,UserRole.Admin.ToString());
			return RedirectToAction(nameof(Index), "Home");
		}
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginVm loginVm,string? ReturnUrl)
		{
			if (!ModelState.IsValid)
			{ return View(); }

			AppUser User = await _userManager.FindByNameAsync(loginVm.UserNameOrEmail);
            if (User is null)
            {
				User = await _userManager.FindByEmailAsync(loginVm.UserNameOrEmail);
				if (User is null)
				{
					ModelState.AddModelError("", "Username or password is invalid");
					return View();
				}
            }
			var result =  _signInManager.CheckPasswordSignInAsync(User, loginVm.Password, true).Result;
			if (result.IsLockedOut)
			{
				ModelState.AddModelError(String.Empty, "sonra yeniden cehd et");
				return View();
			}
			if (!result.Succeeded)
			{
				ModelState.AddModelError(String.Empty, "Username or password is invalid");
				return View();
			}

			await _signInManager.SignInAsync(User, loginVm.RememberMe);

			if(ReturnUrl != null && !ReturnUrl.Contains("Login"))
			{
				return Redirect(ReturnUrl);
			}


			return RedirectToAction(nameof(Index) , "Home");

		}
		public IActionResult LogOut()
		{
			_signInManager.SignOutAsync();
			return RedirectToAction(nameof(Index),"Home");
		}

		//public async Task<IActionResult> CreateRole()
		//{
		//	foreach(var item in Enum.GetValues(typeof(UserRole))){
		//		if (await _roleManager.FindByNameAsync(item.ToString()) != null)
		//		{
		//			await _roleManager.cre
		//		} ;
		//	};
  //          return RedirectToAction(nameof(Index), "Home");
		//}



	}
	
	
}
