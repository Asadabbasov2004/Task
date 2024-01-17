using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using we.Models;

namespace we.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
