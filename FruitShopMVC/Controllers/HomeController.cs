﻿using FruitShopMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FruitShopMVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

      
    }
}
