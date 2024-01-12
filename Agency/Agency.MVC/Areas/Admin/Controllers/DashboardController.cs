using Microsoft.AspNetCore.Mvc;

namespace Agency.MVC.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
