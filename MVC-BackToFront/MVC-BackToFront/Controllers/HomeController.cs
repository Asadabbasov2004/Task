using Microsoft.AspNetCore.Mvc;

namespace MVC_BackToFront.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
