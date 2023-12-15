using Microsoft.AspNetCore.Mvc;

namespace Indigo_Mvc.Contollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
