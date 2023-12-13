using Microsoft.AspNetCore.Mvc;

namespace Dinana_mvc.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
