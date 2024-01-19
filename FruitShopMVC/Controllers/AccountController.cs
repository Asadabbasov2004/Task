﻿using FruitShopMVC.Models;
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
        
        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Register(RegisterVm vm) {
            if (!ModelState.IsValid)
            {
                return View(vm);
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
             //await _userManager.AddToRoleAsync(user, "Admin");
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

    }
}