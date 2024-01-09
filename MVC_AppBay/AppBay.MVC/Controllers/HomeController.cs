using AppBay.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppBay.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
         {

            return View();
        }
    }
}
