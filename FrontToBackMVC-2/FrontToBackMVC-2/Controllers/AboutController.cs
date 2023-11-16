using Microsoft.AspNetCore.Mvc;

namespace FrontToBackMVC_2.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
